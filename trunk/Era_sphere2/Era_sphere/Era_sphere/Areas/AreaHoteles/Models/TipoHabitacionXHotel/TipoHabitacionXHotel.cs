using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaHoteles.Models.Hotel;

namespace Era_sphere.Areas.AreaHoteles.Models.TipoHabitacionXHotel
{
    public class TipoHabitacionXHotel
    {
        [Required]
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }
        [Required]
        [ForeignKey("hotel")]
        public int HotelID { get; set; }


        [Required]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal Precio { get; set; }




        public virtual TipoHabitacion tipoHabitacion { get; set; }
        public virtual Hotel hotel { get; set; }
    }
}