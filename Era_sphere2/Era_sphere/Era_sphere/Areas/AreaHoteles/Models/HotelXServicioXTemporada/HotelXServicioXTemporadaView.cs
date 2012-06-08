using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM
{
    public class HotelXServicioXTemporadaView : IValidatableObject
    {
        public HotelXServicioXTemporadaView()
        {
        }

        public HotelXServicioXTemporadaView(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public HotelXServicioXTemporadaView(HotelXServicioXTemporada hxsxt)
        {
            this.ID = hxsxt.ID;

            this.servicio_descripcion = hxsxt.servicio.descripcion;
            this.tt_desc = hxsxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxsxt.temporada.descripcion;
            this.precio = hxsxt.precio;

            this.hotelID = hxsxt.hotelID;
            this.servicioID = hxsxt.servicioID;
            this.temporadaID = hxsxt.temporadaID;
        }

        [Required]
        public int ID { get; set; }


        [Required]
        [DisplayName("Precio ($)")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }


        [Required]
        public int hotelID { get; set; }
        [Required]
        [DisplayName("Servicio")]
        public int servicioID { get; set; }
        [Required]
        [DisplayName("Temporada")]
        public int temporadaID { get; set; }

        
        [DisplayName("Servicio")]
        public string servicio_descripcion { get; set; }
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }
        [DisplayName("Temporada")]
        public string t_desc { get; set; }



        public HotelXServicioXTemporada deserializa()
        {
            return new HotelXServicioXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                servicioID = this.servicioID,
                temporadaID = this.temporadaID,
                precio = this.precio
            };
        }

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field = new[] { "precio" };
            //var field2 = new[] { "tipoHabitacionID" };

            //if (precio < (new EraSphereContext()).servicios.Find(servicioID).)
            //{
            //    yield return new ValidationResult("El precio debe ser mayor o igual al base", field);
            //}

            int nrep = (new EraSphereContext()).hxsxts.Count(hxthxt => hxthxt.hotelID == hotelID && hxthxt.servicioID == servicioID && hxthxt.temporadaID == temporadaID);

            if (1 <= nrep)
            {
                yield return new ValidationResult("Este servicio ya fue asignado un precio en esta temporada (contradictorio)", field);
            }
        }
    }
}