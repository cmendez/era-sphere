using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class LogicaTemporada:InterfazLogicaTemporada
    {
        EraSphereContext temporada_context = new EraSphereContext();
        DBGenericQueriesUtil<Temporada> database_table;

        public LogicaTemporada()
        {
            database_table = new DBGenericQueriesUtil<Temporada>(temporada_context, temporada_context.temporadas);
        }

        public List<TemporadaView> retornarTemporadas()
        {
            List<Temporada> temporadas = database_table.retornarTodos();
            List<TemporadaView> temporadas_view = new List<TemporadaView>();

            foreach (Temporada temporada in temporadas) temporadas_view.Add(new TemporadaView(temporada));
            return temporadas_view;
        }

        public TemporadaView retornarTemporada(int temporadaID)
        {
            Temporada temporada_aux = database_table.retornarUnSoloElemento(temporadaID);
            TemporadaView temporada = new TemporadaView(temporada_aux);
            return temporada;
        }

        public void modificarTemporada(TemporadaView temporada_view)
        {
            Temporada temporada = temporada_view.deserializa(this);            
            database_table.modificarElemento(temporada, temporada.ID);
        }

        public void agregarTemporada(TemporadaView temporada)
        {
            database_table.agregarElemento(temporada.deserializa(this));
        }

        public void eliminarTemporada(int temporadaID)
        {
            database_table.eliminarElemento(temporadaID);
        }

        public List<Temporada> buscarTemporada(Temporada temporada_campos)
        {
            return database_table.buscarElementos(temporada_campos);
        }


        public List<Temporada> retornarTemporadas2()
        {
            return database_table.retornarTodos();
        }
    }
}