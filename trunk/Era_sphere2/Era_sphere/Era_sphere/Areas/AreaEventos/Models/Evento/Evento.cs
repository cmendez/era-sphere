﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class Evento : DBable, Costeable
    {
        #region atributos
        public DateTime fecha_inicio { get; set; }
        
        public string nombre { get; set; }

        public string dni { get; set; }

        public decimal precio_total { get; set; }
        
        public int num_participantes { get; set; }

        public decimal pagado { get; set; }


        //[ForeignKey("hotel")]
        public int hotel { get; set; }
        //[Required]
        //public virtual Hotel hotel { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente> eventoXAmbiente { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.Participante.Participante> participantes { get; set; }

        public virtual ICollection<Adicional> adicionales { get; set; }
        
        public int estado_eventoID { get; set; }
        
        //[ForeignKey("cliente_evento")]
        //public int cliente_eventoID { get; set; }
        //public virtual Cliente cliente_evento { get; set; }
        ////[ForeignKey("cliente")]
        public string detalle { get; set; }

        public virtual ICollection<Servicio> evento_servicios { get; set; }
        //public virtual Cliente cliente { get; set; }

        #endregion

        public List<ReciboLinea> getReciboLineas()
        {
            EraSphereContext context = new EraSphereContext();
            List<ReciboLinea> lineas = context.recibos_linea_x_evento.Where(x => x.eventoID == ID).ToList().Select(y => context.recibos_lineas.Find(y.recibo_lineaID)).ToList();
            return lineas;
        }
        public void registraReciboLinea(ReciboLinea linea)
        {
            EraSphereContext context = new EraSphereContext();
            context.recibos_lineas.Add(linea);
            context.SaveChanges();
            ReciboLineaXEvento x = new ReciboLineaXEvento { recibo_lineaID = linea.ID, eventoID = ID };
            context.recibos_linea_x_evento.Add(x);
            context.SaveChanges();
        }
        public int getHotelID()
        {
            return hotel;
        }
        public int getPagadorID()
        {
            return 2;
        }
        public void generaReciboLineas()
        {
            if (pagado > 0)
            {
                ReciboLinea paguito = new ReciboLinea("Pago del adelanto", pagado, 1, DateTime.Now, false);
                registraReciboLinea(paguito);
            }
        }
        public void setEspacioRentableNombre(string s)
        {

        }
        public string getEspacioRentableNombre()
        {
            return "gg";
        }
    }
}