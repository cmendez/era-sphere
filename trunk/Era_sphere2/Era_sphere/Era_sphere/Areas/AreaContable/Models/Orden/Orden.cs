using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Orden
{
    public class Orden:DBable
    {
        public virtual Empleado empleado_solicita { get; set; }
        public int empleado_solicitaID { get; set; }

        public bool estado { get; set; }
        public DateTime fechapedido{get;set;}
        public DateTime fechaentrega{get;set;}
        public double Total { get; set; }


        public virtual ICollection<OrdenLinea> ordenlinea { set; get; }
        public int ordenlineaID { get; set; }

    }
}
