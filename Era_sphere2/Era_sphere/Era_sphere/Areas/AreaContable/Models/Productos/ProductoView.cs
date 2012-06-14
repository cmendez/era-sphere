using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ProductoView : IValidatableObject
    {
        public ProductoView() { }
        public ProductoView(Producto producto)
        {
            ID = producto.ID;
            descripcion = producto.descripcion;
            isPerecible = producto.isPerecible;
            isPerecible_str = producto.isPerecible ? "Si" : "No";
            lineaProductoID = producto.lineaProductoID;
            if (lineaProductoID != null)
                lineaProducto_str = (new EraSphereContext()).lineasproducto.Find(lineaProductoID).descripcion;
            else
                lineaProducto_str = "--";
            diasPerecible = producto.diasPerecible;
            unidadMedidad = producto.unidadMedidad;
        }

        public Producto deserializa(InterfazLogicaProducto logica)
        {
            return new Producto
            {
                descripcion = this.descripcion,
                ID = this.ID,
                isPerecible = this.isPerecible,
                diasPerecible = isPerecible ? this.diasPerecible : 0,
                unidadMedidad = this.unidadMedidad,
                lineaProductoID = this.lineaProductoID
            };
        }

        [DisplayName("ID Producto")]
        public int ID { get; set; }

        [Required, StringLength(50)]
        [DisplayName("Producto")]
        public string descripcion { get; set; }

        //****?
        [Required]
        [DisplayName("Linea")]
        public int lineaProductoID { get; set; }
        [DisplayName("Linea")]
        public string lineaProducto_str { get; set; }

        //[Required]
        //public int clasProductoID { get; set; }
        //[DisplayName("Clasificación")]
        //public string clasProducto_desc { get; set; }

        [Required]
        [DisplayName("Perecible")]
        public bool isPerecible { get; set; }
        [DisplayName("Perecible")]
        public string isPerecible_str { get; set; }

        //[Required]
        [Range(0,30)]
        [DisplayName("Tiempo de expiración (días)")]
        public int diasPerecible { get; set; }

        [Required, StringLength(10)]
        [DisplayName("U.M.")]
        public string unidadMedidad { get; set; }
        // (p.e. CAJAX25, BOLSAX10, GR., LATAS, BIDON)

        //**en prodxprov
        //[Required]
        //[DisplayFormat(NullDisplayText="--")]
        //[DisplayName("Cod. de Proveedor (opcional)")]
        //public int codProv { get; set; }

        public IEnumerable<ValidationResult>
            Validate(ValidationContext validationContext)
        {
            //IValidatableObject
            var field = new[] { "diasPerecible" };
            //var field2 = new[] { "tipoHabitacionID" };

            if (isPerecible)
            {
                if (diasPerecible == null) 
                    yield return new ValidationResult("Debe especificar este campo si el producto es perecible", field);
                if (diasPerecible == 0)
                    yield return new ValidationResult("Este campo debe ser mayor a 0 días si el producto es perecible", field);

            }


            //if (precio < (new EraSphereContext()).tipos_habitacion.Find(tipoHabitacionID).costo_base)
            //{
            //    yield return new ValidationResult("El precio debe ser mayor o igual al base", field);
            //}

            //int nrep = (new EraSphereContext()).hxthxts.Count(hxthxt => hxthxt.hotelID == hotelID && hxthxt.tipoHabitacionID == tipoHabitacionID && hxthxt.temporadaID == temporadaID);

            //if (1 <= nrep)
            //{
            //    yield return new ValidationResult("Este tipo de habitacion ya fue asignado un precio en esta temporada (contradictorio)", field);
            //}
        }
    }
}