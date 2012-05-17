using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaPiso
    {
        void agregarPiso(PisoView piso);
        void modificarPiso(PisoView piso_view);
        void eliminarPiso(int piso_id);
        List<PisoView> retornarPisos(int hotel_id);
        PisoView retornarPiso(int piso_id);
        //HotelView retornarPiso(int ciudad_id);
        //List<EspacioCargable> retornarEspaciosCargables(int piso_id);
    }
}