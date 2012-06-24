using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM
{
    public class HotelXProductoView : IValidatableObject
    {
        public HotelXProductoView()
        {
        }

        public HotelXProductoView(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public HotelXProductoView(HotelXProducto hxp)
        {
            this.ID = hxp.ID;

            this.hotelID = hxp.hotelID;
            this.linea_prodID = (new EraSphereContext()).productos.Find(hxp.productoID).lineaProductoID;
            this.linea_prod_str = (new EraSphereContext()).lineasproducto.Find(this.linea_prodID).descripcion;
            this.productoID = hxp.productoID;
            this.producto_str = (new EraSphereContext()).productos.Find(hxp.productoID).descripcion;
            this.monedaID = hxp.monedaID;
            this.moneda_str = (new EraSphereContext()).monedas.Find(hxp.monedaID).simbolo;
            this.precio = hxp.precio;
        }

        //DBable
        [Required]
        public int ID { get; set; }


        //HotelXProducto
        [Required]
        public int hotelID { get; set; }

        [DisplayName("Linea de producto")]
        public int linea_prodID { get; set; }
        [DisplayName("Linea de producto")]
        public string linea_prod_str { get; set; }

        [Required]
        [DisplayName("Producto")]
        public int productoID { get; set; }
        [DisplayName("Producto")]
        public string producto_str { get; set; }
        
        [Required]
        [DisplayName("Moneda")]
        public int monedaID { get; set; }
        [DisplayName("Moneda")]
        public string moneda_str { get; set; }

        [Required]
        [DisplayName("Precio")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public double precio { get; set; }

        public HotelXProducto deserializa()
        {
            return new HotelXProducto
            {
                ID = this.ID,
                hotelID = this.hotelID,
                productoID = this.productoID,
                monedaID = this.monedaID,
                precio = this.precio
            };
        }

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var fieldpc = new[] { "precio" };
            var fieldlp = new[] { "linea_prodID" };
            var fieldp = new[] { "productoID" };
            var fieldm = new[] { "monedaID" };

            if (this.linea_prodID == 0)
            {
                yield return new ValidationResult("El campo Linea de producto es obligatorio", fieldlp);
            }

            if (this.productoID == 0)
            {
                yield return new ValidationResult("El campo producto es obligatorio", fieldp);
            }

            if (this.monedaID == 0)
            {
                yield return new ValidationResult("El campo moneda es obligatorio", fieldm);
            }

            int nrep = (new EraSphereContext()).hxps.Count(hxp => hxp.hotelID == hotelID && hxp.productoID == productoID);

            if (1 <= nrep)
            {
                yield return new ValidationResult("Este producto ya fue asignado un precio de venta (contradictorio)", fieldpc);
            }
        }
    }
}