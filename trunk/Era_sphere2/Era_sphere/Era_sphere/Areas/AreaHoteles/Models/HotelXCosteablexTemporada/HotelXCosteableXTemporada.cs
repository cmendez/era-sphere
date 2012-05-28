using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXCosteable
{
    public class HotelXCosteableXTemporada : DBable
    {
        [Required]
        [ForeignKey("hotel")]
        public int hotelID { get; set; }
        [Required]
        [ForeignKey("costeable")]
        public int costeableID { get; set; }
        [Required]
        [ForeignKey("temporada")]
        public int temporadaID { get; set; }




        public virtual Hotel hotel { get; set; }
        public virtual Costeable costeable { get; set; }
        public virtual Temporada temporada { get; set; }
    }
}