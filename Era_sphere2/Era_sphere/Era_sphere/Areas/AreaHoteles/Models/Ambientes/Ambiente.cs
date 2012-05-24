using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Ambiente: EspacioRentable
    {
        public string nombre { get; set; }
        public int capacidad_maxima { get; set; }
        public int num_niveles { get; set; }
    }
}