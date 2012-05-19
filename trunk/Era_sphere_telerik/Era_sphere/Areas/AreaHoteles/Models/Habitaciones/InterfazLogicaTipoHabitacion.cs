using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public interface InterfazLogicaTipoHabitacion
    {
        List<TipoHabitacion> retornarTiposHabitacion();
        Habitacion retornarTipoHabitacion(int tipohabitacion_id);
        void modificarTipoHabitacion(TipoHabitacion tipohabitacion);
        void agregarTipoHabitacion(TipoHabitacion tipohabitacion);
        void eliminarTipoHabitacion(int tipohabitacion_id);
        List<Habitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion);
    }
}