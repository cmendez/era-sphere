using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEmpleados.Models
{
    public class Empleado : Persona
    {
        public string estado { get; set; }
        public string tarjeta_empleado { get; set; }
        public string cad_horario { get; set; }
        public string cad_horas { get; set; }
        public byte[] cvitae { get; set; }
        public decimal sueldo { get; set; }

    }
}