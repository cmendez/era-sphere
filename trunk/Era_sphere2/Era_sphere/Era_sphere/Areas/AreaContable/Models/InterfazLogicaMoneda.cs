using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaContable.Models
{
    interface InterfazLogicaMoneda
    {
        List<Moneda> RetornarMonedas();
        Moneda retornarMoneda(int idmoneda);
        
        void modificarMoneda(Moneda moneda);
        void agregarMoneda(Moneda moneda);
        void eliminarMoneda(int idmoneda);

        List<Moneda> buscarMoneda(Pais idPais);
    }
}