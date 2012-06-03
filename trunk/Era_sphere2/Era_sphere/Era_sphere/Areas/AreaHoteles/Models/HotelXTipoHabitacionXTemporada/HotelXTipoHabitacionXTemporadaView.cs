using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM
{
    public class HotelXTipoHabitacionXTemporadaView
    {
        public HotelXTipoHabitacionXTemporadaView()
        {
        }

        public HotelXTipoHabitacionXTemporadaView(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public HotelXTipoHabitacionXTemporadaView(HotelXTipoHabitacionXTemporada hxthxt)
        {
            this.ID = hxthxt.ID;

            this.tipoHabitacion_descripcion = hxthxt.tipoHabitacion.descripcion;
            this.tt_desc = hxthxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxthxt.temporada.descripcion;
            this.precio = hxthxt.precio;

            this.hotelID = hxthxt.hotelID;
            this.tipoHabitacionID = hxthxt.tipoHabitacionID;
            this.temporadaID = hxthxt.temporadaID;
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
        [DisplayName("TipoHabitacion")]
        public int tipoHabitacionID { get; set; }
        [Required]
        public int temporadaID { get; set; }

        
        [DisplayName("TipoHabitacion")]
        public string tipoHabitacion_descripcion { get; set; }
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }
        [DisplayName("Temporada")]
        public string t_desc { get; set; }



        public HotelXTipoHabitacionXTemporada deserializa()
        {
            return new HotelXTipoHabitacionXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                tipoHabitacionID = this.tipoHabitacionID,
                temporadaID = this.temporadaID,
                precio = this.precio
            };
        }
    }
}