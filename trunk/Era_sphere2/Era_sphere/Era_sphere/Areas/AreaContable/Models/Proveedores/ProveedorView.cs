using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ProveedorView
    {
        public ProveedorView() { }
        public ProveedorView(Proveedor proveedor)
        {
            // TODO: Complete member initialization
            ID = proveedor.ID;          
            razon_social = proveedor.razon_social;
            ruc = proveedor.ruc;            
            direccion = proveedor.direccion;
            correo = proveedor.correo;
            telefono = proveedor.telefono;
            persona_contacto = proveedor.persona_contacto;            
        }
        [Required]
        [DisplayName("Razon Social")]
        public string razon_social { get; set; }       
        
        [Required]
        [DisplayName("RUC")]
        [RegularExpression(StringsDeValidaciones.numeric)]
        public string ruc { get; set; }        

        [Required]
        [DisplayName("Direccion")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Correo")]
        public string correo { get; set; }
        
        [Required, StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        [DisplayName("Telefono")]
        public string telefono { get; set; }

        [Required]
        [DisplayName("Persona de Contacto")]
        public string persona_contacto { get; set; }

        [DisplayName("ID Proveedor")]
        public int ID { get; set; }

        public Proveedor deserializa(InterfazLogicaProveedor logica)
        {
            return new Proveedor
            {
                razon_social=this.razon_social,                
                ruc=this.ruc,
                direccion = this.direccion,                
                ID = this.ID,
                correo=this.correo,
                telefono=this.telefono,
                persona_contacto=this.persona_contacto,                
            };
        }
    }
}