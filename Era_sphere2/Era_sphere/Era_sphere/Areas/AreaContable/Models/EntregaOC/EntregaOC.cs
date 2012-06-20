using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class EntregaOC:DBable
    {
        public EntregaOC() { productos = new HashSet<EOCLinea>(); }
        public DateTime fecha_entrega { get; set; }
        public virtual ICollection<EOCLinea> productos { get; set;}
        public virtual OrdenCompra orden_compra { get; set; }
        public int orden_compraID { get; set; }
    }
}