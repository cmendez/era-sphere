using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public interface InterfazLogicaTipoDePago
    {
        void agregarTipoDePago(TipoDePagoView tipodepago);
        void modificarTipoDePago(TipoDePagoView tipodepago);
        void eliminarTipoDePago(int tipodepago_id);
        List<TipoDePagoView> retornarTiposDePagos();
        TipoDePagoView retornarTipoDePago(int hotel_id);
    }
}
