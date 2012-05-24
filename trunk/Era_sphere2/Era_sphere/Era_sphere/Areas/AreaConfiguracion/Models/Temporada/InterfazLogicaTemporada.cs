using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    interface InterfazLogicaTemporada
    {
        void modificarTemporada(TemporadaView temporada);
        void agregarTemporada(TemporadaView temporada);
        void eliminarTemporada(int temporada_id);
        List<TemporadaView> retornarTemporadas();
        TemporadaView retornarTemporada(int temporada_id);
        List<Temporada> buscarTemporada(Temporada temporada);

    }
}
