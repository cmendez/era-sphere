using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaContable.Models.Orden
{
    public class proveedor_x_producto
    {
        public int idproducto { get; set; }
        public int idproveedor { get; set; }
        public double  precioU { get; set; }
    }
}