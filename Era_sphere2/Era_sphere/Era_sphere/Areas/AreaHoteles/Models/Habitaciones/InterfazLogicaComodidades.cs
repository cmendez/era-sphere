using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models;
namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    interface InterfazLogicaComodidades
    {

        List<ComodidadView> retornarComodidades();
        ComodidadView retornarComodidad (int comodidad_id);
        void modificarComodidad(ComodidadView comodidad);
        void agregarComodidad(ComodidadView comodidad);
        void eliminarComodidad(int comodidad_id);
        //List<Comodidad> buscarProveedor(Comodidad comodidad);
        List<ComodidadView> retornarComodidades(int tipoHabitacionID);
    }
}

