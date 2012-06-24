using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class EOCLineaView
    {
        public EOCLineaView() { }
        public EOCLineaView(EOCLinea eocl)
        {
            productoID = eocl.linea_oc.productoID;
            producto = eocl.linea_oc.producto.producto.descripcion;
            cantidad = eocl.cantidad_entregada;
            precio_total = eocl.linea_oc.precio_total;
            precio_unitario = (decimal)eocl.linea_oc.producto.precio_unitario;
            ID = eocl.ID;
            entregaID = eocl.entregaID;
            fecha_entrega = eocl.entrega.fecha_entrega;
            linea = eocl.linea_oc.producto.producto.lineaProducto.descripcion;
            monto_entrega = eocl.entrega.monto_entrega;
            //falta incluir la colección de ENTREGAS
        }
        [DisplayName("Pago Entrega")]
        public decimal monto_entrega { get; set; }
        [DisplayName("Linea")]
        public string linea { get; set; }
        [DisplayName("Fecha Entrega")]
        public DateTime fecha_entrega { get; set; }
        [DisplayName("Nro Entrega")]
        public int entregaID { get; set; }
        public int ID { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal precio_unitario { get; set; }
        [DisplayName("ID Prod")]
        public int productoID { get; set; }
        [DisplayName("Producto")]
        public string producto { get; set; }
        [DisplayName("Entregado")]
        public int cantidad { get; set; }
        [DisplayName("Precio Total")]
        public decimal precio_total { get; set; }
    }
}