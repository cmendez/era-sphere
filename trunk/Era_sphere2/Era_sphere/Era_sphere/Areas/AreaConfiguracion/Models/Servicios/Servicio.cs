using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class Servicio : DBable//, Costeable
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
                
        //si su precio es fijado, usa el valor dado por precio_fijado
        public bool es_precio_fijado {get; set;}
        public decimal precio_fijado {get; set;}

        public decimal precio_normal { get; set; }

        public decimal precio_final { get { return es_precio_fijado ? precio_fijado : repeticiones * precio_normal; } }

        public ICollection<ReciboLinea> recibo_lineas { get; set; }

        public List<ReciboLinea> getReciboLineas()
        {
            EraSphereContext context = new EraSphereContext();
            return context.recibo_linea_x_servicio.Where(x => x.servicioID == ID).Select(x => context.recibos_lineas.Find(x.recibo_lineaID)).ToList();
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
            ReciboLinea linea = new ReciboLinea(tipo_servicio.nombre + ": " + this.descripcion, precio_final, 0, DateTime.Now, false);
            EraSphereContext context = new EraSphereContext();
            context.recibos_lineas.Add(linea);
            ReciboLineaXServicio x = new ReciboLineaXServicio { recibo_lineaID = linea.ID, servicioID = ID };
            context.recibo_linea_x_servicio.Add(x);

        }


        public void setEspacioRentableNombre()
        {
            throw new NotImplementedException();
        }


        [ForeignKey("evento")]
        public int eventoID { get; set; }
        public Evento evento { get; set; }


        public void getEspacioRentableNombre()
        {
            throw new NotImplementedException();
        }

    }
}