using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class PagoTarjeta:DBable
    {
        public PagoTarjeta() { }

        [DisplayName("Monto")]
        public Double monto { get; set; }

        [DisplayName("Metodo")]
        public String Metodo_pago { get; set; }//visa, mastercard,american express, cmr, saga
        
        [DisplayName("Mes")]
        public string mes_caduca_tarjeta { get; set; }

        [DisplayName("Año")]
        public string año_caduca_tarjeta { get; set; }

        [DisplayName("CS")]
        public string codigo_seguridad { get; set; }

        [DisplayName("Idmoneda")]
        public int idmoneda { get; set; }
        public Moneda moneda { get; set; }
    }
}