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
            ID = proveedor.ID;
            razon_social = proveedor.razon_social;
            ruc = proveedor.ruc;
            direccion = proveedor.direccion;
            telefono = proveedor.telefono;
            correo = proveedor.correo;
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
        [DisplayName("Dirección")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [Required, StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        [DisplayName("Teléfono")]
        public string telefono { get; set; }

        [DisplayName("ID Proveedor")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Persona de Contacto")]
        public string persona_contacto { get; set; }

        public Proveedor deserializa(InterfazLogicaProveedor logica)
        {
            return new Proveedor
            {
                direccion = this.direccion,
                ruc = this.ruc,
                ID = this.ID,
                razon_social = this.razon_social,
                telefono = this.telefono,
                correo = this.correo,
                persona_contacto = this.persona_contacto,
            };
        }
    }
}