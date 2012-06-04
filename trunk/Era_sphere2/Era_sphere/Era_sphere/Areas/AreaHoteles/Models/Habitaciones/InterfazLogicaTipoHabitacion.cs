using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaTipoHabitacion
    {
        List<TipoHabitacionView> retornarTiposHabitacion();
        //List<TipoHabitacionView> retornarTiposHabitacion(int hotel_id);
        TipoHabitacionView retornarTipoHabitacion(int tipohabitacion_id);
        void modificarTipoHabitacion(TipoHabitacionView  tipoHabitacion);
        void agregarTipoHabitacion(TipoHabitacionView tipoHabitacion);
        void eliminarTipoHabitacion(int tipohabitacion_id);
        List<TipoHabitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion);
        TipoHabitacion retornarObjTipoHabitacion(int tipohabitacion_id);
        void agregarComodidades(int tipohabitacion_id,int [] checkedRecords);
    }
}