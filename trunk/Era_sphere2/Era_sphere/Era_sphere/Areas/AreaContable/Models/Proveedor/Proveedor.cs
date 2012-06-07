using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using Era_sphere.Areas.AreaHoteles.Models;


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
        public virtual ICollection<proveedor_x_producto> productos { get; set; }
        public virtual ICollection<Hotel> hoteles { get; set;  }
        public ICollection<proveedor_x_producto> getProductos() { return productos; }
    }
}