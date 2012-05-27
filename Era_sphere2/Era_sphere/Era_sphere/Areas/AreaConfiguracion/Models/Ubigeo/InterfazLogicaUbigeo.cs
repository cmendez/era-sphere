using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public interface InterfazLogicaUbigeo
    {
        void modificarPais(PaisView pais);
        List<PaisView> retornarPaises();
    }
}