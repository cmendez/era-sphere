using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class proveedor_x_producto : DBable
    {

        [ForeignKey("producto")]
        public int productoID { get; set; }
        
        [ForeignKey("proveedor")]
        public int proveedorID { get; set; }
        
        public virtual Producto producto { get; set; }
        public virtual Proveedor proveedor { get; set; }

        public double  precio_unitario { get; set; }
    }
}