using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class LogicaComodidades : InterfazLogicaComodidades
    {
        ComodidadesContext comodidad_context = new ComodidadesContext();
        DBGenericQueriesUtil<Comodidad> database_table;
        //DBGenericQueriesUtil<EstadoComodidad> table_estado;

        public LogicaComodidades()
        {
            database_table = new DBGenericQueriesUtil<Comodidad>(comodidad_context, comodidad_context.comodidades);
       }

        public List<Comodidad> retornarComodidades()
        {
            //return new List<Comodidad>() { new Comodidad { ID = 1, descripcion = "jp" } };
            return database_table.retornarTodos();
        }


        public void agregarComodidad(Comodidad comodidad)
        {
            //int id = comodidad.estadoID;
            database_table.agregarElemento(comodidad);
        }

        public void eliminarComodidad(int comodidad_id)
        {
            database_table.eliminarElemento(comodidad_id);
        }

        public void modificarComodidad(Comodidad comodidad)
        {
            database_table.modificarElemento(comodidad, comodidad.ID);
        }
    }
}