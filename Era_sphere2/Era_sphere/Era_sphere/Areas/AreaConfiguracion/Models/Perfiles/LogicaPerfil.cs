using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Perfiles
{
    public class LogicaPerfil
    {
        PerfilContext perfil_context = new PerfilContext();
        DBGenericQueriesUtil<Perfil> database_table;
        DBGenericQueriesUtil<Cliente> database_table_clientes;

        public LogicaPerfil()
        {
            database_table = new DBGenericQueriesUtil<Perfil>(perfil_context, perfil_context.perfiles);
        }

        public List<Perfil> retornarPerfiles()
        {
            return database_table.retornarTodos();
        }

        public Perfil retornarPerfil(int perfilID)
        {
            return database_table.retornarUnSoloElemento(perfilID);
        }

        public void modificarPerfil(Perfil perfil)
        {
            database_table.modificarElemento(perfil, perfil.ID);
        }

        public void agregarPerfil(Perfil perfil)
        {
            database_table.agregarElemento(perfil);
        }

        public void eliminarPerfil(int perfilID)
        {
            database_table.eliminarElemento(perfilID);
        }

        public List<Perfil> buscarPerfil(Perfil perfil_campos)
        {
            return database_table.buscarElementos(perfil_campos);
        }

        public List<Cliente> retornarClientes()
        {
            return database_table_clientes.retornarTodos();
        }

    }
}