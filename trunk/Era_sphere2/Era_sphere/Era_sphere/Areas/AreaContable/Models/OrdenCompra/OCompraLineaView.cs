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
            cantidad_recibida = ocl.cantidad_recibida;
            precio_total = ocl.precio_total;
            precio_unitario = (decimal)ocl.precio_unitario;
            ID = ocl.ID;
            precio_boleta = ocl.precio_recibidos;
            unidad_medida = ocl.producto.producto.unidadMedidad;
            //falta incluir la colección de ENTREGAS
        }
        [DisplayName("Unidad")]
        public string unidad_medida { get; set; }
        public int ID { get; set; }

        [DisplayName("Precio Unitario")]
        public decimal precio_unitario { get; set; }
        [DisplayName("ID Prod")]
        public int productoID { get; set; }
        [DisplayName("Producto")]
        public string producto { get; set; }
        [DisplayName("Cantidad Ordenada")]
        public int cantidad { get; set; }
        [DisplayName("Cantidad Recibida")]
        public int cantidad_recibida {get; set;}
        [DisplayName("Precio Total")]
        public decimal precio_total { get; set; }
        [DisplayName("Precio Recibidos")]
        public decimal precio_boleta { get; set; }
    }
}