using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaReportes.Models.ReporteEmpleados
{
    public class FormReporteEmpleado
    {
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellido paterno")]
        public string apePaterno { get; set; }
        [DisplayName("Apellido materno")]
        public string apeMaterno { get; set; }
        [DisplayName("Fecha inicio")]
        public DateTime fechaInicio { get; set; }
        [DisplayName("Fecha fin")]
        public DateTime fechaFin { get; set; }
        //public int comboboxAsistencia  
    }
}