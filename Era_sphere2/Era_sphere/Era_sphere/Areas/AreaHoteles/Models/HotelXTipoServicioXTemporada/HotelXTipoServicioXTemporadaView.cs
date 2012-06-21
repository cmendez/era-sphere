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
    public class HotelXTipoServicioXTemporadaView : IValidatableObject
    {
        public HotelXTipoServicioXTemporadaView()
        {
        }

        public HotelXTipoServicioXTemporadaView(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public HotelXTipoServicioXTemporadaView(HotelXTipoServicioXTemporada hxsxt)
        {
            this.ID = hxsxt.ID;

            this.tipo_servicio_descripcion = hxsxt.tipo_servicio.descripcion;
            this.tt_desc = hxsxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxsxt.temporada.descripcion;
            this.precio = hxsxt.precio;

            this.hotelID = hxsxt.hotelID;
            this.tipo_servicioID = hxsxt.tipo_servicioID;
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
        [DisplayName("Tipo de Servicio")]
        public int tipo_servicioID { get; set; }
        [Required]
        [DisplayName("Temporada")]
        public int temporadaID { get; set; }

        
        [DisplayName("Tipo de Servicio")]
        public string tipo_servicio_descripcion { get; set; }
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }
        [DisplayName("Temporada")]
        public string t_desc { get; set; }



        public HotelXTipoServicioXTemporada deserializa(LogicaHotelXTipoServicioXTemporada logica)
        {
            return new HotelXTipoServicioXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                hotel = logica.hxsxt_context.hoteles.Find(this.hotelID),
                tipo_servicioID = this.tipo_servicioID,
                tipo_servicio = logica.hxsxt_context.tipo_servicios.Find(this.tipo_servicioID),
                temporadaID = this.temporadaID,
                temporada = logica.hxsxt_context.temporadas.Find(this.temporadaID),
                precio = this.precio
            };
        }

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field = new[] { "precio" };

            int nrep = (new EraSphereContext()).hxsxts.Count(hxthxt => hxthxt.hotelID == hotelID && hxthxt.tipo_servicioID == tipo_servicioID && hxthxt.temporadaID == temporadaID);

            if (1 <= nrep)
            {
                yield return new ValidationResult("Este servicio ya fue asignado un precio en esta temporada (contradictorio)", field);
            }
        }
    }
}