using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM
{
    public class HotelXTipoHabitacionXTemporada : DBable
    {
        [Required]
        [ForeignKey("hotel")]
        public int hotelID { get; set; }
        [Required]
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }
        [Required]
        [ForeignKey("temporada")]
        public int temporadaID { get; set; }
        [Required]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; } //en $

        //public HotelXPreciableXTemporada(){
        //var res = from dbset x where 
        //}


        public virtual Hotel hotel { get; set; }
        public virtual TipoHabitacion tipoHabitacion { get; set; }
        public virtual Temporada temporada { get; set; }
    }
}
