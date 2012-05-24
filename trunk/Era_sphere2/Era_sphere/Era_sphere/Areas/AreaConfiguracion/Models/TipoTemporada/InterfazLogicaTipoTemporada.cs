using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    interface InterfazLogicaTipoTemporada
    {
        void modificarTipoTemporada(TipoTemporadaView tipotemporada);
        void agregarTipoTemporada(TipoTemporadaView tipotemporada);
        void eliminarTipoTemporada(int tipotemporada_id);
        List<TipoTemporadaView> retornarTiposTemporada();
        TipoTemporadaView retornarTipoTemporada(int tipotemporada_id);
        List<TipoTemporada> buscarTipoTemporada(TipoTemporada tipotemporada);

    }
}
