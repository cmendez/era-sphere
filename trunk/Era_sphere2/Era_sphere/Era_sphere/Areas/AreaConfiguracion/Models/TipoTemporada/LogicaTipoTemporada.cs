using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.TipoTemporada
{
    public class LogicaTipoTemporada:InterfazLogicaTipoTemporada
    {
        TipoTemporadaContext tipotemporada_context = new TipoTemporadaContext();
        DBGenericQueriesUtil<TipoTemporada> database_table;

        public LogicaTipoTemporada()
        {
            database_table = new DBGenericQueriesUtil<TipoTemporada>(tipotemporada_context, tipotemporada_context.tipostemporada);
       }

        public List<TipoTemporada> retornarTiposTemporada()
        {
            return database_table.retornarTodos();
        }


        public void agregarTipoTemporada(TipoTemporada tipotemporada)
        {
            database_table.agregarElemento(tipotemporada);
        }

        public void eliminarTipoTemporada(int tipotemporada_id)
        {
            database_table.eliminarElemento(tipotemporada_id);
        }

        public void modificarTipoTemporada(TipoTemporada tipotemporada)
        {
            database_table.modificarElemento(tipotemporada, tipotemporada.ID);
        }

    }
}