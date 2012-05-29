using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaContable.Models.Orden
{
    public class OrdenLinea
    {
        public int id_producto_x_proveedor { get; set; }
        public double cantidad { get; set; }
        public double precioU { get; set; }
        public double SubTotal { get; set; }
        public bool estado { get; set; }
        public DateTime fechaentrega { get; set; }

        public virtual proveedor_x_producto p_x_p { get; set; }

    }
}