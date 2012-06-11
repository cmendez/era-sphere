using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaReportes.Models.ReporteEmpleados
{
    public class ObjetoReporteEmpleado
    {
        public string empleadoID { get; set; }
        public string nombreCompleto { get; set; }
        public DateTime? fecha { get; set; }
        public string asistencia { get; set; }
    }
}