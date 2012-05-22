using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class LogicaTipoHabitacion
    {
        TipoHabitacionContext tipohabitacion_context = new TipoHabitacionContext();
        DBGenericQueriesUtil<TipoHabitacion> database_table;
        
        public LogicaTipoHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< TipoHabitacion >(tipohabitacion_context, tipohabitacion_context.tiposhabitacion);
        }

        public List<TipoHabitacion> retornarTipoHabitaciones()
        {
            return database_table.retornarTodos();
        }

        public TipoHabitacion retornarTipoHabitacion(int tipohabitacionID)
        {
            return database_table.retornarUnSoloElemento(tipohabitacionID);
        }

        public void modificarTipoHabitacion(TipoHabitacion tipohabitacion)
        {
            database_table.modificarElemento(tipohabitacion, tipohabitacion.ID);
        }

        public void agregarTipoHabitacion(TipoHabitacion tipohabitacion)
        {
            database_table.agregarElemento(tipohabitacion);
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