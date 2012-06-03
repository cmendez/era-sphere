using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleado
{
    public class AsistenciaEmpleado : DBable
    {
        public string empleadoID  { get; set; }

        public DateTime? fechaHoraEntrada { get; set; }
        public DateTime? fechaHoraSalida { get; set; }
        public string asistencia { get; set; }
        
        
    }
}