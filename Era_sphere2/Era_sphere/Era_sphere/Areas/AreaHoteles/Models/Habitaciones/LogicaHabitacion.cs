using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaHabitacion:InterfazLogicaHabitacion
    {
        EraSphereContext habitacion_context = new EraSphereContext();
        DBGenericQueriesUtil<Habitacion> database_table;
        
        public LogicaHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< Habitacion >(habitacion_context, habitacion_context.habitaciones);
        }

        public List<HabitacionView> retornarHabitaciones()
        {
            List<Habitacion> habitaciones = database_table.retornarTodos();
            List<HabitacionView> habitacion_view = new List<HabitacionView>();

            foreach (Habitacion habitacion in habitaciones) habitacion_view.Add(new HabitacionView(habitacion));
            return habitacion_view;
        }

        public HabitacionView retornarHabitacion(int habitacion_id)
        {
            Habitacion habitacion = database_table.retornarUnSoloElemento(habitacion_id);
            HabitacionView habitacion_view = new HabitacionView(habitacion);
            return habitacion_view;
        }

        public void modificarHabitacion(HabitacionView habitacion_view)
        {
            Habitacion habitacion = habitacion_view.deserializa(this);
            database_table.modificarElemento(habitacion, habitacion.ID);
            return;
        }

        public void agregarHabitacion(HabitacionView habitacion)
        {
            database_table.agregarElemento(habitacion.deserializa(this));
        }

        public void eliminarHabitacion(int habitacion_id)
        {
            database_table.eliminarElemento(habitacion_id);
        }

        /*public List<Habitacion> buscarHabitacion(Habitacion habitacion_campos)
        {
            return database_table.buscarElementos(habitacion_campos);
        }*/
    }
}