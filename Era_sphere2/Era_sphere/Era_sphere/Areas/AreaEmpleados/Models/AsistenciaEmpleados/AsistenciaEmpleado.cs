using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados
{
    public class AsistenciaEmpleado : DBable
    {
        [DisplayName("Codigo Empleado")]
        public string empleadoID { get; set; }
        [DisplayName("Fecha y hora de entrada")]
        public DateTime? fechaHoraEntrada { get; set; }
        [DisplayName("Fecha y hora de salida")]
        public DateTime? fechaHoraSalida { get; set; }
        [DisplayName("Asistencia")]
        public string s_asistencia { get; set; }

    }
}