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
            perecible_str = pp.producto.isPerecible ? "Si , vence en " + pp.producto.diasPerecible  + " dias" :"No.";
            precio_unitario = pp.precio_unitario;
        }

        [Required]
        [DisplayName("ID Producto")]
        public int productoID { get; set; }

        [DisplayName("Descripcion")]
        public string descripcion_producto { get; set; }


        [DisplayName("Es Perecible?")]
        public string perecible_str { get; set; }
        
        public int ID { get; set; }

        public int proveedorID { get; set; }
        
    
        [Required]
        [DisplayName("Precio Unitario") , DataType(DataType.Currency)]
        public double precio_unitario { get; set;}
    }
}