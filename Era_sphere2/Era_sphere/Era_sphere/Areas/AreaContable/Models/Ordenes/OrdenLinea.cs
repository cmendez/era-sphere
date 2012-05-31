using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class OrdenLinea : DBable
    {

        [ForeignKey("proveedor_x_producto")]
        public int producto_x_proveedorID { get; set; }

        public virtual proveedor_x_producto proveedor_x_producto { get; set; }

        public double cantidad { get; set; }
        public double precioU { get; set; }
        public double SubTotal { get; set; }
        public bool estado { get; set; }
        public DateTime fechaentrega { get; set; }

        
        
        [ForeignKey("orden")]
        public int ordenID  { get; set; }

        public Orden orden { get; set; }
    }
}