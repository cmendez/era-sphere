using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models;
namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    interface InterfazLogicaComodidades
    {

        List<Comodidad> retornarComodidades();
        //Comodidad retornarComodidad (int comodidad_id);
        void modificarComodidad(Comodidad comodidad);
        void agregarComodidad(Comodidad comodidad);
        void eliminarComodidad(int comodidad_id);
        //List<Comodidad> buscarProveedor(Comodidad comodidad);

    }
}

