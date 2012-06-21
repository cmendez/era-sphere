using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaPromociones.Models
{
    interface InterfazLogicaPromocion
    {
        //EraSphereContext promocion_context { get; }
        void modificarPromocion(PromocionView promocion);
        void agregarPromocion(PromocionView promocion);
        void eliminarPromocion(int promocion_id);
        List<PromocionView> retornarPromociones();
        PromocionView retornarPromocion(int promocion_id);
        List<Promocion> buscarPromocion(Promocion promocion);
    }
}
