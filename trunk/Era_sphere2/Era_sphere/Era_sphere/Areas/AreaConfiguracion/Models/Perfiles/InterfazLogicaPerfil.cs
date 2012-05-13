using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Perfiles
{
    public interface InterfazLogicaPerfil
    {
        List<Perfil> retornarPerfiles();
        Perfil retornarPerfil(int perfil_id);
        void modificarPerfil(Perfil perfil);
        void agregarPerfil(Perfil perfil);
        void eliminarPerfil(int perfil_id);
        List<Perfil> buscarPerfil(Perfil perfil);
    }
}