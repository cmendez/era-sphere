using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class TipoDePago
    {
        public TipoDePago() { }

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Idpagotarjeta")]
        public int idpagotarjeta { get; set; }
        public PagoTarjeta tarjeta { get; set; }

        [DisplayName("IdPagoEfectivo")]
        public int idpagoEfectivo { get; set; }
        public PagoEfectivo efectivo { get; set; }

    }
}