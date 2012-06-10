using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class proveedor_x_productoView
    {
        public proveedor_x_productoView(){}
        public proveedor_x_productoView(proveedor_x_producto pp)
        {
            ID = pp.ID;
            productoID = pp.productoID;
            proveedorID = pp.proveedorID;
            descripcion_producto = pp.producto.descripcion;
            precio_unitario = pp.precio_unitario;
        }
        public int ID { get; set; }
        [Required]
        [DisplayName("Producto") ]
        
        public int productoID { get; set; }
        public int proveedorID { get; set; }
        
        [ReadOnly(true)]
        [DisplayName("Descripcion")]
        public string descripcion_producto { get; set; }
        [Required]
        [DisplayName("Precio Unitario")]
        public double precio_unitario { get; set;}
    }
}