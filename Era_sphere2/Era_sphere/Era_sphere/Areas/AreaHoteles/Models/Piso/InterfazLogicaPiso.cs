using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaPiso
    {
        void modificarPiso(PisoView piso);
        void agregarPiso(PisoView piso);
        void eliminarPiso(int piso_id);
        List<PisoView> retornarPisos();
        PisoView retornarPiso(int piso_id);
        List<Piso> buscarPiso(Piso piso);
        //leo un hotel_id
        string retornaNombreHotel(int hotel_id);
    }
}