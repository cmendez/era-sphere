using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Orden
{
    public class proveedor_x_producto
    {
        [ForeignKey("producto")]
        public int idproducto { get; set; }
        
        [ForeignKey("proveedor")]
        public int idproveedor { get; set; }

        public double  precioU { get; set; }
    }
}