using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaEmpleados.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class Orden : DBable
    {
        //public int vtalon { get; set; }

        public int? empleado_solicitaID { get; set; }
        public virtual Empleado empleado_solicita { get; set; }

        public virtual ICollection<OrdenLinea> ordenlineas { set; get; }

        public int estado { get; set; } //0 reg 1 parc 2 total
        public DateTime fechaRegistro { get; set; }
        public double total { get; set; }
        public double totalIGV { get; set; }

        public int nro_lineas { get; set; }
    }
}
