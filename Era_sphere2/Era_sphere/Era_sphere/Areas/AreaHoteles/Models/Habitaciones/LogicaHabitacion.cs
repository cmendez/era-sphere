using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaHabitacion:InterfazLogicaHabitacion
    {
        HabitacionContext habitacion_context = new HabitacionContext();
        DBGenericQueriesUtil<Habitacion> database_table;
        
        public LogicaHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< Habitacion >(habitacion_context, habitacion_context.habitaciones);
        }

        public List<Habitacion> retornarHabitaciones()
        {
            return database_table.retornarTodos();
        }

        public Habitacion retornarHabitacion(int habitacionID)
        {
            return database_table.retornarUnSoloElemento(habitacionID);
        }

        public void modificarHabitacion(Habitacion habitacion)
        {
            database_table.modificarElemento(habitacion, habitacion.ID);
        }

        public void agregarHabitacion(Habitacion habitacion)
        {
            database_table.agregarElemento(habitacion);
        }

        public void eliminarHabitacion(int habitacionID)
        {
            database_table.eliminarElemento(habitacionID);
        }

        public List<Habitacion> buscarHabitacion(Habitacion habitacion_campos)
        {
            return database_table.buscarElementos(habitacion_campos);
        }
    }
}