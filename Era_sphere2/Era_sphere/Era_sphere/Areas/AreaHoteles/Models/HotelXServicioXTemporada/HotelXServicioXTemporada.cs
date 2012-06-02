using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM
{
    public class HotelXServicioXTemporada : DBable
    {
        [Required]
        [ForeignKey("hotel")]
        public int hotelID { get; set; }
        [Required]
        [ForeignKey("servicio")]
        public int servicioID { get; set; }
        [Required]
        [ForeignKey("temporada")]
        public int temporadaID { get; set; }
        [Required]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public int precio { get; set; } //en $

        //public HotelXPreciableXTemporada(){
        //var res = from dbset x where 
        //}


        public virtual Hotel hotel { get; set; }
        public virtual Servicio servicio { get; set; }
        public virtual Temporada temporada { get; set; }



 //       public HotelXServicioXTemporada(int ID, int hotelID, int servicioID, int temporadaID)
 //       {
 //           this.ID = ID;
 //           this.hotelID = hotelID;
 //           this.servicioID = servicioID;
 //           this.temporadaID = temporadaID;
 //       }


    }
}
