﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Ordenes;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class Producto : DBable
    {
        [ForeignKey("lineaProducto")]
        public int lineaProductoID { get; set; }
        public virtual LineaProducto lineaProducto { get; set; }

        public String descripcion { get; set; }

        public bool isPerecible { get; set; }
        public int diasPerecible { get; set; }

        public string unidadMedidad { get; set; }

        //public int? codProv { get; set; }



        public virtual ICollection<proveedor_x_producto> proveedores { get; set; }
        public ICollection<proveedor_x_producto> getProveedores() { return proveedores; }
    }
}