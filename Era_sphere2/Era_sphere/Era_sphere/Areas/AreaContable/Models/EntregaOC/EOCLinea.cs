using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class EOCLinea: DBable
    {
        public virtual EntregaOC entrega { get; set; }
        public int entregaID { get; set; }
        public virtual OCompraLinea linea_oc { get; set; }
        public int linea_ocID { get; set; }
        public int cantidad_entregada { get; set; }
    }
}