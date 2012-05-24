using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Ambiente: EspacioCargable
    {
        public string nombre { get; set; }
        public int capacidad_personas { get; set; }     
        public int hotelID { get; set; }
    }
}