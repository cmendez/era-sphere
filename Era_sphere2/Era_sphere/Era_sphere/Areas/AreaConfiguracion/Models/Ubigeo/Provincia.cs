using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.Configuracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class Provincia
    {
        public string Nombre { get; set; }
        public Ciudad Ciudad { get; set; }
        public Pais Pais { get; set; }
    }
}