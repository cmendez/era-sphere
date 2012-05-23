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
        public int num_niveles { get; set; }
        public int largo { get; set; }
        public int ancho { get; set; }
        public int area { get { return largo * ancho; } }
    }
}