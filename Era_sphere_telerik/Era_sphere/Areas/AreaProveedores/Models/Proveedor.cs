using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaProveedores.Models
{
    public class Proveedor: DBable
    {
        public Proveedor() { }
        [DisplayName("Razon Social")]
        public string razon_social { get; set; }
        [DisplayName("Ruc")]
        public string ruc { get; set; }
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        [DisplayName("Correo Electronico")]
        public string correo { get; set; }
        [DisplayName("Telefono")]
        public string telefono { get; set; }
        [DisplayName("Persona de contacto")]
        public string persona_de_contacto { get; set; }
        [DisplayName("Estado")]
        public int estadoID { get; set; }
        public EstadoProveedor estado { get; set; }
        
    }
}