using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class OCompraLinea : DBable
    {
        [ForeignKey("orden_compra")]
        public int orden_compraID { get; set; }
        public virtual OrdenCompra orden_compra { get; set; }
        public int productoID { get; set; }
        public virtual proveedor_x_producto producto { get; set; }
        public int cantidad { get; set;  }
        public int cantidad_recibida { get; set; }
        public decimal precio_total { get; set; }
        public virtual ICollection<EOCLinea> entregas { get; set; }
    }
}