using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class LogicaTipoTemporada:InterfazLogicaTipoTemporada
    {
        EraSphereContext tipotemporada_context = new EraSphereContext();
        DBGenericQueriesUtil<TipoTemporada> database_table;

        public LogicaTipoTemporada()
        {
            database_table = new DBGenericQueriesUtil<TipoTemporada>(tipotemporada_context, tipotemporada_context.tipostemporada);
        }

        public List<TipoTemporadaView> retornarTiposTemporada()
        {
            List<TipoTemporada> tipostemporada = database_table.retornarTodos();
            List<TipoTemporadaView> tipostemporada_view = new List<TipoTemporadaView>();

            foreach (TipoTemporada tipotemporada in tipostemporada) tipostemporada_view.Add(new TipoTemporadaView(tipotemporada));
            return tipostemporada_view;
        }

        public TipoTemporadaView retornarTipoTemporada(int tipotemporadaID)
        {
            TipoTemporada tipotemporada_aux = database_table.retornarUnSoloElemento(tipotemporadaID);
            TipoTemporadaView tipotemporada = new TipoTemporadaView(tipotemporada_aux);
            return tipotemporada;
        }

        public void modificarTipoTemporada(TipoTemporadaView tipotemporada_view)
        {
            TipoTemporada tipotemporada = tipotemporada_view.deserializa(this);
            TipoTemporada orig = database_table.retornarUnSoloElemento(tipotemporada_view.ID);
            orig.descripcion = tipotemporada.descripcion ?? orig.descripcion;
            database_table.modificarElemento(orig, tipotemporada.ID);
        }

        public void agregarTipoTemporada(TipoTemporadaView tipotemporada)
        {
            database_table.agregarElemento(tipotemporada.deserializa(this));
        }

        public void eliminarTipoTemporada(int tipotemporadaID)
        {
            database_table.eliminarElemento(tipotemporadaID);
        }

        public List<TipoTemporada> buscarTipoTemporada(TipoTemporada tipotemporada_campos)
        {
            return database_table.buscarElementos(tipotemporada_campos);
        }



    }
}