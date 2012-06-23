using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class ReciboLineaXEvento:DBable
    {
        public int recibo_lineaID { get; set; }
        public int eventoID { get; set; }
    }
}