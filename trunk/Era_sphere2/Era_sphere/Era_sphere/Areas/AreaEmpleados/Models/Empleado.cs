using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaEmpleados.Models
{
    public class Empleado : Persona
    {
        public string nombre_cargo { get; set; }
        public string estado { get; set; }
        //public string tarjeta_empleado { get; set; }
        public string cad_horario { get; set; }
        public string cad_horasIn { get; set; }
        public string cad_horasOut { get; set; }
        //public byte[] cvitae { get; set; }
        public string sueldo { get; set; }

       // [ForeignKey("perfil")]
        public int perfilID { get; set; }
       // public virtual Perfil perfil { get; set; }

        public Empleado() { }

    }
    
}