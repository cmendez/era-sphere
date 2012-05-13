using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Perfiles
{
    public class InterfazLogicaPerfil
    {
        List<Cliente> retornarClientes();
        Perfil retornarperfil(int perfil_id);
        void modificarperfil(Perfil perfil);
        void agregarperfil(Perfil perfil);
        void eliminarperfil(int perfil_id);
        List<Perfil> buscarperfil(Perfil perfil);
    }
}