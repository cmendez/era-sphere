using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class Proveedor : DBable
    {
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string persona_contacto { get; set; }
    }
}