using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaContable.Models
{
    interface InterfazLogicaTipoDePago
    {
        List<PagoTarjeta> retornarTarjetaPagos();
        PagoTarjeta retornarTarjetaPago(int idpagotarjeta);

        void ModificarTarjetaPago(PagoTarjeta tarjeta);
        void agregarTarjetaPago(PagoTarjeta tarjeta);
        void eliminarTarjetaPago(int idpagotarjeta);

        List<PagoTarjeta> buscarTarjetaPago(PagoTarjeta tarjeta);
      
    }
}
