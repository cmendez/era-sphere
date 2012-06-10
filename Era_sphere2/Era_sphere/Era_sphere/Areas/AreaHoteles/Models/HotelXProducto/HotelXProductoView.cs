using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM
{
    public class HotelXProductoView //: IValidatableObject
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

        //public IEnumerable<ValidationResult>
        //   Validate(ValidationContext validationContext)
        //{
        //    var field = new[] { "precio" };

        //    int nrep = (new EraSphereContext()).hxsxts.Count(hxthxt => hxthxt.hotelID == hotelID && hxthxt.servicioID == servicioID && hxthxt.temporadaID == temporadaID);

        //    if (1 <= nrep)
        //    {
        //        yield return new ValidationResult("Este servicio ya fue asignado un precio en esta temporada (contradictorio)", field);
        //    }
        //}
    }
}