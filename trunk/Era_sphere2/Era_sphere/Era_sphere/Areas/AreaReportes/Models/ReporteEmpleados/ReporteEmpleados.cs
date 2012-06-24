using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaReportes.Models.ReporteEmpleados
{
    public class ReporteEmpleado
    {
        public String fileName { get; set; }
        public String[,] titulo { get; set; }
        public String[,] cabecera { get; set; }
        public String[][] contenido { get; set; }
    }
}