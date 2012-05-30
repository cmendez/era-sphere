using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public interface InterfazLogicaEvento
    {
        List<EventoView> retornarEventos(int hotel_id);
        EventoView retornarEvento(int evento_id);
        void modificarEvento(EventoView evento);
        void agregarEvento(EventoView evento);
        void eliminarEvento(int evento_id);
        //List<Habitacion> buscarHabitacion(Habitacion habitacion);
    }
}