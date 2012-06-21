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
    public class Servicio : DBable, Costeable
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
        
        //si su precio es fijado, usa el valor dado por precio_fijado
        public bool es_precio_fijado {get; set;}
        public decimal precio_fijado {get; set;}
        

        public List<ReciboLinea> getReciboLineas()
        {
            throw new NotImplementedException();
        }

        public int getHotelID()
        {
            throw new NotImplementedException();
        }

        public int getPagadorID()
        {
            throw new NotImplementedException();
        }

        public void generaReciboLineas()
        {
            throw new NotImplementedException();
        }
    }
}