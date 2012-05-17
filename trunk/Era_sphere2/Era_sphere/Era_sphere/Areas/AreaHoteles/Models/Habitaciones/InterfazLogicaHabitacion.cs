using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaHabitacion
    {
        List<Habitacion> retornarHabitaciones();
        Habitacion retornarHabitacion(int habitacion_id);
        void modificarHabitacion(Habitacion habitacion);
        void agregarHabitacion(Habitacion habitacion);
        void eliminarHabitacion(int habitacion_id);
        List<Habitacion> buscarHabitacion(Habitacion habitacion);
    }
}