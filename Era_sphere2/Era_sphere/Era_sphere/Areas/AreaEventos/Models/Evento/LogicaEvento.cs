using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class LogicaEvento
    {
        EraSphereContext evento_context = new EraSphereContext();
        DBGenericQueriesUtil<Evento> database_table;
        
        public LogicaEvento()
        {   
            database_table = new DBGenericQueriesUtil< Evento >(evento_context, evento_context.eventos);
        }

        public List<EventoView> retornarEventos( int id_hotel )
        {
            IEnumerable<Evento> eventos = database_table.retornarTodos();//Where( p => p.piso.hotel.ID == id_hotel );
            List<EventoView> evento_view = new List<EventoView>();

            foreach (Evento evento in eventos) evento_view.Add(new EventoView(evento));
            return evento_view;
        }

        public EventoView retornarEvento(int evento_id)
        {
            Evento evento = database_table.retornarUnSoloElemento(evento_id);
            EventoView evento_view = new EventoView(evento);
            return evento_view;
        }

        public Evento retornarObjEvento(int evento_id)
        {
            return database_table.retornarUnSoloElemento(evento_id);
        }
        public void modificarEvento(EventoView evento_view)
        {
            Evento modif = evento_view.deserializa();  
            database_table.modificarElemento(modif, modif.ID);
            return;
        }

        public void agregarEvento(EventoView evento)
        {
            Evento evento_per = evento.deserializa();
            //habitacion_per.tipoHabitacion = habitacion_context.tipos_habitacion.Find(habitacion_per.tipoHabitacionID);
            //habitacion_per.estado = habitacion_context.estado_espacio_rentable.Find(habitacion.estado_habitacionID);
            //habitacion_per.piso = habitacion_context.pisos.Find(habitacion.pisoID);
            database_table.agregarElemento(evento_per);
        }

        public void eliminarEvento(int habitacion_id)
        {
            database_table.eliminarElemento(habitacion_id);
        }

        /*public List<Habitacion> buscarHabitacion(Habitacion habitacion_campos)
        {
            return database_table.buscarElementos(habitacion_campos);
        }*/
    }
}