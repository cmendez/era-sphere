﻿using System;
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
        //con esta función se retorna el nombre del hotel
        string retornaNombreHotel(int hotel_id);
        List<PisoView> retornarPisoHotel(int hotel_id);
    }
}