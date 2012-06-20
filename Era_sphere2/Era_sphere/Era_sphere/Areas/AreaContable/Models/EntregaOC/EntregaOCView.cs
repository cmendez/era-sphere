using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class EntregaOCView
    {
        public EntregaOCView() { }
        public EntregaOCView(EntregaOC eoc)
        {
            entregaID = eoc.ID; //de DBable
            fecha_entrega = eoc.fecha_entrega; //fecha           
            nro_productos = eoc.productos.Count; //ICollection <EOCLinea> productos          
            ordencompraID = eoc.orden_compraID; //virtual OrdenCompra y orden_compraID
            nombre_proveedor = eoc.orden_compra.proveedor.razon_social; // nombre del proveedor
        }
        [DisplayName("#Entrega")]
        public int entregaID { get; set; }
        [DisplayName("# Productos")]
        public int nro_productos { get; set; }
        [DisplayName("Fecha de Entrega")]
        public DateTime? fecha_entrega { get; set; }
        public int ordencompraID { get; set; }
        [DisplayName("Nombre Proveedor")]
        public string nombre_proveedor { get; set; }
    }
}