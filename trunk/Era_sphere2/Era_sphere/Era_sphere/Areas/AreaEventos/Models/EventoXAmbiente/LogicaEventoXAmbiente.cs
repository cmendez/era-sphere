using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class LogicaEventoXAmbiente
    {
        EraSphereContext exa_context = new EraSphereContext();
        DBGenericQueriesUtil<EventoXAmbiente> database_table;
        //DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaEventoXAmbiente()
        {
            database_table = new DBGenericQueriesUtil<EventoXAmbiente>(exa_context, exa_context.eventoXAmbientes);
            //database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxsxt_context, hxsxt_context.hoteles);
        }


        public List<EventoXAmbienteView> retornarAmbientes(int eventoid)
        {
            List<EventoXAmbiente> exa = database_table.retornarTodos();
            exa.Where(e => e.eventoID == eventoid);
            List<EventoXAmbienteView> exaview = new List<EventoXAmbienteView>();
            foreach (EventoXAmbiente e in exa)
            {
                exaview.Add(new EventoXAmbienteView(e));
            }
            return exaview;
        }
        /*
        public void agregarServicioXTemporada(int id, HotelXServicioXTemporadaView pxtv)
        {
            database_table.agregarElemento(pxtv.deserializa());
        }

        public void eliminarServicioXTemporada(int id, int servicioXTemporada_id)
        {
            database_table.eliminarElemento(servicioXTemporada_id);
            return;
        }

        public void modificarServicioXTemporada(int id, HotelXServicioXTemporadaView pxtv)
        {
            HotelXServicioXTemporada hpt = pxtv.deserializa();
            database_table.modificarElemento(hpt, hpt.ID);
            return;
        }

        public string retornaNombreHotel(int hotel_id)
        {
            Hotel hotel_perteneciente = database_table_hotel.retornarUnSoloElemento(hotel_id);
            return hotel_perteneciente.razon_social;
        }
        */
        
    }
}