using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Era_sphere.Areas.AreaPromociones.Models
{
    interface InterfazLogicaPromocion
    {
        void modificarPromocion(PromocionView promocion);
        void agregarPromocion(Promocion promocion);
        void eliminarPromocion(int promocion_id);
        List<PromocionView> retornarPromociones();
        PromocionView retornarPromocion(int promocion_id);
        List<Promocion> buscarPromocion(Promocion promocion);
    }
}
