using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class Servicio : Costeable
    {
        public Servicio() {
        }

        public string descripcion { get; set; }

        [ForeignKey("tipo_servicio")]
        public int tipo_servicioID { get; set; }
        public TipoServicio tipo_servicio { get; set; }

        public virtual ICollection<ProductoXServicio> productos { get; set; }

        public DateTime? fecha_y_hora { get; set; }
        public int repeticiones { get; set; }

        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public string campo3 { get; set; }

        public virtual ICollection<ReciboLineaServicio> recibos_linea { get; set; }
        
        public override List<ReciboLinea> generarReciboLineas()
        {
            return null;
            /*if (recibos_linea.Count() > 0) return recibos_linea;
            var lista = new List<ReciboLineaServicio>();
            ReciboLinea rec = new ReciboLinea(descripcion, 0, this.repeticiones);
            lista.Add(rec);
            if (tipo_servicio.tiene_productos_asociados)
            {
                   foreach (var pxs in productos)
                       lista.Add(new ReciboLinea(pxs.producto.descripcion, 1, pxs.unidades));
            }
            return lista;*/
        }
    }
}