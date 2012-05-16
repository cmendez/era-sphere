using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class PagoEfectivo:DBable
    {
        public PagoEfectivo() { }

        [DisplayName("Monto")]
        public Double monto { get; set; }

        [DisplayName("Idmoneda")]
        public int idmoneda { get; set; }
        public Moneda moneda { get; set; }
    }
}