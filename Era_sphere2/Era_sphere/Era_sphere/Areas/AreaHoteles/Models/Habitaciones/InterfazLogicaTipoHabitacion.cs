using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaTipoHabitacion
    {
        List<TipoHabitacionView> retornarTiposHabitacion();
        TipoHabitacionView retornarTipoHabitacion(int tipohabitacion_id);
        void modificarTipoHabitacion(TipoHabitacionView  tipoHabitacion);
        void agregarTipoHabitacion(TipoHabitacionView tipoHabitacion);
        void eliminarTipoHabitacion(int tipohabitacion_id);
     //   List<Habitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion);
    }
}