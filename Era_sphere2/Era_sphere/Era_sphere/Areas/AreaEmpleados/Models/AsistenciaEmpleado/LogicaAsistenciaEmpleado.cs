using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleado;

namespace Era_sphere.Areas.AreaAsistenciaEmpleados.Models
{
    public class LogicaAsistenciaEmpleado : InterfazLogicaAsistenciaEmpleado
    {
        EraSphereContext asistenciaEmpleado_context = new EraSphereContext();
        DBGenericQueriesUtil<AsistenciaEmpleado> database_table;


        public LogicaAsistenciaEmpleado()
        {
            database_table = new DBGenericQueriesUtil<AsistenciaEmpleado>(asistenciaEmpleado_context, asistenciaEmpleado_context.asistenciaEmpleado);
        }

        public void agregarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado)
        {
            database_table.agregarElemento(AsistenciaEmpleado);
        }
        /*
        public List<AsistenciaEmpleado> retornarAsistenciaEmpleados()
        {
            return database_table.retornarTodos();
        }

        public AsistenciaEmpleado retornarAsistenciaEmpleado(int AsistenciaEmpleadoID)
        {
            return database_table.retornarUnSoloElemento(AsistenciaEmpleadoID);
        }

        public void modificarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado)
        {
            database_table.modificarElemento(AsistenciaEmpleado, AsistenciaEmpleado.ID);
        }



        public void eliminarAsistenciaEmpleado(int AsistenciaEmpleadoID)
        {
            database_table.eliminarElemento(AsistenciaEmpleadoID);
        }

        public List<AsistenciaEmpleado> buscarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado_campos)
        {
            return database_table.buscarElementos(AsistenciaEmpleado_campos);
        }

        */
    }
}