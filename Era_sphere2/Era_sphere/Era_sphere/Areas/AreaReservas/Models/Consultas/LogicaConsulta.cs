using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class LogicaConsulta
    {
        public EraSphereContext context = new EraSphereContext();
        //DBGenericQueriesUtil<Cliente> database_table;

        public int retornarNumeroHabitacionesDisponible(Consulta c)
        {
            return c.habitaciones_resultantes.Count();
        }

        public int retornarLibresTipoHabitacion(Consulta consulta, int tipo_habitacion_id)
        {
            int  numero_habitacion_tipo = consulta.habitaciones_resultantes.Where(c => c.tipoHabitacionID == tipo_habitacion_id).Count();
            return numero_habitacion_tipo;
        }

        public int retornarLibresPisos(Consulta consulta, int piso_id)
        {
            int numero_habitacion_piso = consulta.habitaciones_resultantes.Where(c => c.pisoID == piso_id).Count();
            return numero_habitacion_piso;
        }

        
        public void asignarHabitacionesDisponiblesTotales (Consulta consulta)
        {
            int id_hotel = consulta.hotelID;
            LogicaHabitacion logica_habitacion = new LogicaHabitacion();
            consulta.habitaciones_resultantes = logica_habitacion.retornarHabitacionesLibres(id_hotel,consulta.pisoID, consulta.tipo_habitacionID, consulta.fecha_inicio,consulta.fecha_fin);
            if ((consulta.tipo_habitacionID ==0) && (consulta.pisoID == 0))
                consulta.habitaciones_libres_total = retornarNumeroHabitacionesDisponible(consulta);
            if ((consulta.tipo_habitacionID == 0) && (consulta.pisoID !=0))
                consulta.habitaciones_libres_piso = retornarLibresPisos(consulta, consulta.pisoID);
            if ((consulta.tipo_habitacionID!=0) && (consulta.pisoID ==0)) 
                consulta.habitaciones_libres_tipo = retornarLibresTipoHabitacion(consulta, consulta.tipo_habitacionID);
            if ((consulta.tipo_habitacionID != 0) && (consulta.pisoID != 0))
            {
                consulta.habitaciones_libres_tipo = retornarLibresTipoHabitacion(consulta, consulta.tipo_habitacionID);
                consulta.habitaciones_libres_piso = retornarLibresPisos(consulta, consulta.pisoID);
            }
        }
        


    }
}