using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class LogicaEventoXAmbiente
    {
        EraSphereContext exa_context = new EraSphereContext();
        DBGenericQueriesUtil<EventoXAmbiente> database_table;
        DBGenericQueriesUtil<Ambiente> database_table_ambiente;

        public LogicaEventoXAmbiente()
        {
            database_table = new DBGenericQueriesUtil<EventoXAmbiente>(exa_context, exa_context.eventoXAmbientes);
            database_table_ambiente = new DBGenericQueriesUtil<Ambiente>(exa_context, exa_context.ambientes);
            //database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxsxt_context, hxsxt_context.hoteles);
        }


        public List<EventoXAmbienteView> retornarAmbientes(int eventoid)
        {
            List<EventoXAmbiente> exa = database_table.retornarTodos();
            exa = exa.Where(e => e.eventoID == eventoid).ToList();
            List<EventoXAmbienteView> exaview = new List<EventoXAmbienteView>();
            foreach (EventoXAmbiente e in exa)
            {
                exaview.Add(new EventoXAmbienteView(e));
            }
            return exaview;
        }

        
        public void agregarElemento(EventoXAmbienteView exaview)
        {
            database_table.agregarElemento(exaview.deserializa());
        }

        public decimal RetornarCosto(int idEvento)
        {
            decimal costo = 0;
            List <EventoXAmbienteView> listexa= retornarAmbientes(idEvento);    
            foreach (EventoXAmbienteView exa in listexa) {
                decimal dif= (decimal)exa.fecha_hora_fin.Subtract(exa.fecha_hora_inicio).TotalHours ;
                costo += exa.amb_precio*(dif);
            }
            return costo;
        }

        public List<AmbienteView> retonarAmbienteHotel(int idHotel,int idEvento,DateTime fecha_hora_inicio,DateTime fecha_hora_fin)
        {
            List<AmbienteView> libres = (new LogicaAmbiente()).retornarAmbientes(idHotel);
            
            List<EventoXAmbiente> ambientes =database_table.retornarTodos().Where(e=>e.ambiente.piso.hotelID==idHotel).ToList() ;
            
            foreach (EventoXAmbiente ambiente in ambientes) {
                if (DateTimeUtils.tieneInterseccion(ambiente.fecha_hora_inicio, ambiente.fecha_hora_fin, fecha_hora_inicio, fecha_hora_fin))
                {
                    AmbienteView elemento=libres.Find(item=>item.ID==ambiente.ID);
                    libres.Remove(elemento);
                }
            }

            return libres;
        }


    }
}