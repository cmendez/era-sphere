using System;
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

        public int clienteID { get; set; }
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
            linea.fecha = DateTime.Now;
            EraSphereContext context = new EraSphereContext();
            context.recibos_lineas.Add(linea);
            context.SaveChanges();
            ReciboLineaXEvento x = new ReciboLineaXEvento { recibo_lineaID = linea.ID, eventoID = ID };
            context.recibos_linea_x_evento.Add(x);
            context.SaveChanges();
        }
        public void eliminarReciboLinea(int id)
        {
            EraSphereContext context = new EraSphereContext();
            ReciboLinea linea = context.recibos_lineas.Find(id);
            context.recibos_lineas.Remove(linea);
            context.SaveChanges();
            ReciboLineaXEvento x = context.recibos_linea_x_evento.Find(linea.ID);
            context.recibos_linea_x_evento.Remove(x);
            context.SaveChanges();
        }
        public void modificarReciboLinea(ReciboLinea linea,int id)
        {
            EraSphereContext context = new EraSphereContext();
            ReciboLinea recibo = context.recibos_lineas.Find(id);
            recibo.precio_final = linea.precio_final;
            DBGenericQueriesUtil<ReciboLinea> query = new DBGenericQueriesUtil<ReciboLinea>(context, context.recibos_lineas);
            query.modificarElemento(recibo, recibo.ID);
        }
        public int getHotelID()
        {
            return hotel;
        }
        public int getPagadorID()
        {
            string tipo = this.detalle.Substring(this.detalle.LastIndexOf(',') + 2);
            string documento = this.detalle.Substring(this.detalle.LastIndexOf(' ') + 1);
            int tipo_persona, tipo_documentoID;
            if (tipo[0] == 'D') tipo_persona = tipo_documentoID = 1;
            else if (tipo[0] == 'P')
            {
                tipo_persona = 1;
                tipo_documentoID = 2;
            }
            else
            {
                tipo_persona = 2;
                tipo_documentoID = 3;
            }

            if (tipo_persona == 1)
                clienteID = (new EraSphereContext()).clientes.First(c => c.tipoID == tipo_persona && c.documento_identidad == documento && c.tipo_documentoID == tipo_documentoID).ID;
            if (tipo_persona == 2)
                clienteID = (new EraSphereContext()).clientes.First(c => c.tipoID == tipo_persona && c.ruc == documento).ID;

            return clienteID;
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