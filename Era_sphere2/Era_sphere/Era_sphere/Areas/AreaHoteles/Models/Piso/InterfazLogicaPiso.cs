using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public interface InterfazLogicaPiso
    {
        void modificarPiso(PisoView piso);
        void agregarPiso(PisoView piso);
        void eliminarPiso(int piso_id);
        List<PisoView> retornarPisos();
        List<PisoView> retornarPisosDeHotel(int hotel_id);
        PisoView retornarPiso(int piso_id);
        List<Piso> buscarPiso(Piso piso);
        //con esta función se retorna el nombre del hotel
        string retornaNombreHotel(int hotel_id);
        EraSphereContext context_publico { get; }


        void registrarPisosBatch(int idHotel, int nroPisos);

        void eliminarHabsPiso(int p);
    }
}