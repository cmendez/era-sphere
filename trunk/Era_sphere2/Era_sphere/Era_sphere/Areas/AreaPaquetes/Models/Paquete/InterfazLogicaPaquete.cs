using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaPaquetes.Models
{
    public interface InterfazLogicaPaquete
    {

        List<PaqueteView> retornarPaquetes(int hotel_id);
        //List<TipoHabitacionView> retornarTiposHabitacion(int hotel_id);
        PaqueteView retornarPaquete(int paquete_id);
        void modificarPaquete(PaqueteView paquete);
        void agregarPaquete(PaqueteView paquete);
        void eliminarPaquete(int paquete_id);
        //List<Paquete> buscarTipoHabitacion(Paquete paquete);

    }
}