using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaTipoHabitacion:InterfazLogicaTipoHabitacion
    {
        TipoHabitacionContext tipohabitacion_context = new TipoHabitacionContext();
        DBGenericQueriesUtil<TipoHabitacion> database_table;
        
        public LogicaTipoHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< TipoHabitacion >(tipohabitacion_context, tipohabitacion_context.tipos_habitacion);
        }

        public List<TipoHabitacionView> retornarTiposHabitacion()
        {
            List<TipoHabitacion> tipoHabitaciones = database_table.retornarTodos();
            List<TipoHabitacionView> tipoHabitacion_view = new List<TipoHabitacionView>();

            foreach (TipoHabitacion tipoHabitacion in tipoHabitaciones) tipoHabitacion_view.Add(new TipoHabitacionView(tipoHabitacion));
            return tipoHabitacion_view;
        }

        public TipoHabitacionView retornarTipoHabitacion(int tipohabitacion_id)
        {
            TipoHabitacion tipoHabitacion = database_table.retornarUnSoloElemento(tipohabitacion_id);
            TipoHabitacionView tipoHabitacion_view = new TipoHabitacionView(tipoHabitacion);
            return tipoHabitacion_view;
        }

        public void modificarTipoHabitacion(TipoHabitacionView tipoHabitacion_view)
        {
            
            TipoHabitacion tipoHabitacion = tipoHabitacion_view.deserializa(this);
            return;
        }

        public void agregarTipoHabitacion(TipoHabitacionView tipohabitacion)
        {
            database_table.agregarElemento(tipohabitacion.deserializa(this));
        }

        public void eliminarTipoHabitacion(int tipohabitacionID)
        {
            database_table.eliminarElemento(tipohabitacionID);
        }
        public List<TipoHabitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion_campos)
        {
            return database_table.buscarElementos(tipohabitacion_campos);
        }
        
    }
    
}