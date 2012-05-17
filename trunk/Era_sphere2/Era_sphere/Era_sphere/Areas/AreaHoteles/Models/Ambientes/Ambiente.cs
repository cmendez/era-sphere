using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public class Ambiente: DBable
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int pisoID { get; set; }
        public Piso piso { get; set; }
        public int capacidad_personas { get; set; }
        public int num_niveles { get; set; }
        public int largo { get; set; }
        public int ancho { get; set; }
        public int area { get { return largo * ancho; } }
    }
}