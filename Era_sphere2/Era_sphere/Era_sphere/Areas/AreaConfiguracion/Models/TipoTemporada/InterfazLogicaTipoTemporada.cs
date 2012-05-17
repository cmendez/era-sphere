using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Era_sphere.Areas.AreaConfiguracion.Models.TipoTemporada
{
    interface InterfazLogicaTipoTemporada
    {
        List<TipoTemporada> retornarTiposTemporada();
        void modificarTipoTemporada(TipoTemporada tipotemporada);
        void agregarTipoTemporada(TipoTemporada tipotemporada);
        void eliminarTipoTemporada(int comodidad_id);
    }
}
