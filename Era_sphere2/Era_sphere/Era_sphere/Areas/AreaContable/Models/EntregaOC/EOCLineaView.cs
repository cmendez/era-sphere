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
            cantidad = eocl.linea_oc.cantidad;
            precio_total = eocl.linea_oc.precio_total;
            precio_unitario = (decimal)eocl.linea_oc.producto.precio_unitario;
            ID = eocl.ID;
            //falta incluir la colección de ENTREGAS



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