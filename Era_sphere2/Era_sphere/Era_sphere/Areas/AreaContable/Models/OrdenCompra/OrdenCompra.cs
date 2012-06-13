using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class OrdenCompra : DBable
    {
        public OrdenCompra()
        {
            productos = new List<OCompraLinea>();
        }
        virtual public ICollection<OCompraLinea> productos { get; set; }
        public int estado_ordenID { get; set; }
        virtual public EstadoOC estado_orden { get; set; }
        public DateTime? fecha_llegada { get; set; }
        public DateTime? fecha_envio { get; set; }
        public DateTime? fecha_registro { get; set; }
        public int proveedorID { get; set; }
        virtual public Proveedor proveedor { get; set; }
        public decimal monto_total { get; set; }
        public string comentarios { get; set; }
        public int hotelID { get; set; }
        public virtual Hotel hotel { get; set; }

        public void update_precio_total()
        {
            monto_total = 0;
            foreach (var p in productos) monto_total += p.precio_total;
        }
    }
}