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


        [ForeignKey("orden")]
        public int ordenID { get; set; }
        public Orden orden { get; set; }

        public int nroLinea { get; set; }

        [ForeignKey("proveedor_x_producto")]
        public int producto_x_proveedorID { get; set; }

        public virtual proveedor_x_producto proveedor_x_producto { get; set; }

        public double precioU { get; set; }
        public int cantidad { get; set; }
        public double SubTotal { get; set; }
        public int estado { get; set; } // 1 Pendiente 2 Parcial 3 Total 4 cancel
        //public DateTime fechaentrega { get; set; }

        

    }
}