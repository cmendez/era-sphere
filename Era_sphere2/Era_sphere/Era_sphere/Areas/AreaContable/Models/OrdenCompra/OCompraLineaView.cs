using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class OCompraLineaView
    {

        public OCompraLineaView() { }
        public OCompraLineaView( OCompraLinea ocl ){
            productoID = ocl.productoID;
            producto = ocl.producto.producto.descripcion;
            cantidad = ocl.cantidad;
            precio_total = ocl.precio_total;
            precio_unitario = (decimal)ocl.producto.precio_unitario;
            ID = ocl.ID;
        }

        public int ID { get; set; }

        [DisplayName("Precio Unitario")]
        public decimal precio_unitario { get; set; }
        [DisplayName("ID Prod")]
        public int productoID { get; set; }
        [DisplayName("Producto")]
        public string producto { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        [DisplayName("Precio Total")]
        public decimal precio_total { get; set; }
    }
}