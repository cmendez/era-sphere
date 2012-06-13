using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class OrdenCompraView
    {
        public OrdenCompraView() { }
        public OrdenCompraView( OrdenCompra oc ){
            ordenID = oc.ID;
            nro_productos = oc.productos.Count;
            estado_orden = oc.estado_orden.descripcion;
            fecha_envio = oc.fecha_envio;
            fecha_llegada = oc.fecha_llegada;
            fecha_registro = oc.fecha_registro;
            proveedorID = oc.proveedor.ID;
            razon_proveedor = oc.proveedor.razon_social;
            monto_total = oc.monto_total;
            comentarios = oc.comentarios;
            hotelID = oc.hotelID;
            estadoID = oc.estado_ordenID;
        }
        public int estadoID { get; set; }
        public int hotelID { get; set; }
        [DisplayName("#Orden")]
        public int ordenID { get; set; }
        [DisplayName("# Productos")]
        public int nro_productos { get; set; }
        [DisplayName("Estado Orden")]
        public string estado_orden { get; set; }
        [DisplayName("Fecha de llegada")]
        public DateTime ? fecha_llegada { get; set; }
        [DisplayName("Fecha de envio")]
        public DateTime ? fecha_envio { get; set; }
        [DisplayName("Fecha de registro")]
        public DateTime ? fecha_registro { get; set; }
        public int proveedorID { get; set; }
        [DisplayName("Proveedor")]
        public string razon_proveedor { get; set; }
        [DisplayName("Total")]
        public decimal monto_total { get; set; }
        [DisplayName("Comentarios" )]
        public string comentarios { get; set;  }
    }
    
}