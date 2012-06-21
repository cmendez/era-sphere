using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Areas.AreaCargos.Models;

using System.Data.Entity;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM
{
    public class HotelXPreciableXTemporada : DBable
    {
        //[Required]
        [ForeignKey("hotel")]
        public int hotelID { get; set; }
        //[Required]
        [ForeignKey("preciable")]
        public int preciableID { get; set; }
        //[Required]
        [ForeignKey("temporada")]
        public int temporadaID { get; set; }
        //[Required]
        //[Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public int precio { get; set; }

        //public HotelXPreciableXTemporada(){
            //var res = from dbset x where 
        //}


        public virtual Hotel hotel { get; set; }
        public virtual TipoHabitacion preciable { get; set; }
        public virtual Temporada temporada { get; set; }
    }
}