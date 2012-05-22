using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.Configuracion.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace Era_sphere.Generics
{
    public abstract class Persona: DBable
    {
        [DisplayName("Nombres")]
        public string nombre { get; set; }
        
        [DisplayName("Apellido paterno")]
        public string apellido_paterno { get; set; }
        
        [DisplayName("Apellido materno")]
        public string apellido_materno { get; set; }
        
        [DisplayName("DNI")]
        public string dni { get; set; }
       
        [DisplayName("Pasaporte")]
        public string pasaporte { get; set; }
       
        [DisplayName("Correo electronico")]
        public string correo_electronico { get; set; }
       
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        
        [DisplayName("Ruc")]
        public string ruc { get; set; }
        
        [DisplayName("Telefono")]
        public string telefono { get; set; }
        
        [DisplayName("Celular")]
        public string celular { get; set; }
        
        [DisplayName("Razon social")]
        public string razon_social { get; set; }
        
        public byte[] foto { get; set; }
        
        [DisplayName("Ciudad")]
        public Ciudad ciudad { get; set; }

        [DisplayName("Pais")]
        public Pais pais { get; set; }
       
        [DisplayName("Fecha de nacimiento")]
        public DateTime? fecha_nacimiento { get; set; }
        
        [DisplayName("Usuario")]
        public string usuario { get; set; }
       
        [DisplayName("Password")]
        public string password { get; set; }
        
        public enum TipoPersona
        {
            natural,
            juridico
        };
        public TipoPersona tipo { get; set; }
    }
}