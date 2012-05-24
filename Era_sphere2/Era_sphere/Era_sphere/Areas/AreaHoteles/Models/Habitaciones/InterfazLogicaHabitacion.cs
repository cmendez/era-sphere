using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaHabitacion
    {
        List<HabitacionView> retornarHabitaciones( int hotel_id );
        HabitacionView retornarHabitacion(int habitacion_id);
        void modificarHabitacion(HabitacionView habitacion);
        void agregarHabitacion(HabitacionView habitacion);
        void eliminarHabitacion(int habitacion_id);
        //List<Habitacion> buscarHabitacion(Habitacion habitacion);
    }
}