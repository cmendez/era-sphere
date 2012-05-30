using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace Era_sphere.Generics
{
    public abstract class Persona: DBable
    {
        
        public string nombre { get; set; }
                
        public string apellido_paterno { get; set; }
                
        public string apellido_materno { get; set; }
                
        public string dni { get; set; }
       
        public string pasaporte { get; set; }
       
        public string correo_electronico { get; set; }
       
        public string direccion { get; set; }
        
        public string ruc { get; set; }
        
        public string telefono { get; set; }
        
        public string celular { get; set; }
        
        public string razon_social { get; set; }
        
        public byte[] foto { get; set; }

        [ForeignKey("ciudad")]
        public int ciudadID { get; set; }

        public virtual Ciudad ciudad { get; set; }

        [ForeignKey("pais")]
        public int paisID { get; set; }
        
        public virtual Pais pais { get; set; }
        
        public DateTime? fecha_nacimiento { get; set; }
        
        public string usuario { get; set; }
       
        public string password { get; set; }

        public TipoPersona tipo { get; set; }

        public enum TipoPersona{
            natural = 0,
            juridico = 1
        }
    }
}