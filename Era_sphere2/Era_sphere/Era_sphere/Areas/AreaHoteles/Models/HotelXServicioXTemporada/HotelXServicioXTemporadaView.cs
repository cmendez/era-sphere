using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM
{
    public class HotelXServicioXTemporadaView
    {
        public HotelXServicioXTemporadaView()
        {
        }

        public HotelXServicioXTemporadaView(HotelXServicioXTemporada hxsxt)
        {
            this.ID = hxsxt.ID;
            this.servicio_descripcion = hxsxt.servicio.descripcion;
            this.tt_desc = hxsxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxsxt.temporada.descripcion;


            this.hotelID = hxsxt.hotelID;
            this.servicioID = hxsxt.servicioID;
            this.temporadaID = hxsxt.temporadaID;
        }

        [Required]
        public int ID { get; set; }

        [Required]
        [DisplayName("Servicio")]
        public string servicio_descripcion { get; set; }

        [Required]
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }

        [Required]
        [DisplayName("Temporada")]
        public string t_desc { get; set; }

        [Required]
        [DisplayName("Precio")] //dolares
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }




        private int hotelID;
        private int servicioID;
        private int temporadaID;



        public HotelXServicioXTemporada deserializa()
        {
            return new HotelXServicioXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                servicioID = this.servicioID,
                temporadaID = this.temporadaID
            };
        }
    }
}