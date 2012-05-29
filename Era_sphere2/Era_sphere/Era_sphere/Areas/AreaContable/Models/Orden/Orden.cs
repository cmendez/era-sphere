using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;

namespace Era_sphere.Areas.AreaContable.Models.Orden
{
    public class Orden:DBable
    {
        public int idEmpleadoSolicita{get;set;}
        public int idEmpleadoElabora{get;set;}
        public int idEmpleadoAutoriza{get;set;}
        public int idEmpleadoRecibe{get;set;}
        public bool estado { get; set; }
        public DateTime fechapedido{get;set;}
        public DateTime fechaentrega{get;set;}
        public double Total { get; set; }
        

        public virtual Empleado empleado{get;set;}

        public virtual ICollection<OrdenLinea> ordenlinea { set; get; }

    }
}
