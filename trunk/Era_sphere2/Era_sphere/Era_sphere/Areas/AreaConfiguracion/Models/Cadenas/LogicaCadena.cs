using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Cadenas
{
    public class LogicaCadena : InterfazLogicaCadena
    {
        CadenaContext cadena_context = new CadenaContext();
        DBGenericQueriesUtil<Cadena> database_table;

        public LogicaCadena()
        {
            database_table = new DBGenericQueriesUtil<Cadena>(cadena_context, cadena_context.cadenas);
        }

        public List<Cadena> retornarCadenas()
        {
            return database_table.retornarTodos();
        }

        public Cadena retornarCadena(int cadenaID)
        {
            return database_table.retornarUnSoloElemento(cadenaID);
        }

        public void modificarCadena(Cadena cadena)
        {
            database_table.modificarElemento(cadena, cadena.ID);
        }

        public void agregarCadena(Cadena cadena)
        {
            database_table.agregarElemento(cadena);
        }

        public void eliminarCadena(int cadenaID)
        {
            database_table.eliminarElemento(cadenaID);
        }

        public List<Cadena> buscarCadena(Cadena cadena_campos)
        {
            return database_table.buscarElementos(cadena_campos);
        }

        public List<Cadena> retornarClientes()
        {
            return null;
        }
    }
}