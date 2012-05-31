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

        public List<HabitacionView> retornarHabitaciones( int id_hotel )
        {
            IEnumerable<Habitacion> habitaciones = database_table.retornarTodos().Where( p => p.piso.hotel.ID == id_hotel );
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
            Habitacion modif = habitacion_view.deserializa(this);  
            database_table.modificarElemento(modif, modif.ID);
            return;
        }

        public void agregarHabitacion(HabitacionView habitacion)
        {
            Habitacion habitacion_per = habitacion.deserializa(this);
            //habitacion_per.tipoHabitacion = habitacion_context.tipos_habitacion.Find(habitacion_per.tipoHabitacionID);
            habitacion_per.estado = habitacion_context.estado_espacio_rentable.Find(habitacion.estado_habitacionID);
            habitacion_per.piso = habitacion_context.pisos.Find(habitacion.pisoID);
            database_table.agregarElemento(habitacion_per);
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