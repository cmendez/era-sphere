using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public interface InterfazLogicaMoneda
    {
        void agregarMoneda(MonedaView moneda);
        void modificarMoneda(MonedaView moneda);
        void eliminarMoneda(int moneda_id);
        List<MonedaView> retornarMonedas();
        MonedaView retornarMoneda(int moneda_id);
    }
}
