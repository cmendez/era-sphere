using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class ReciboLineaXReserva : DBable
    {
        public int recibo_lineaID { get; set; }
        public int reservaID { get; set; }
    }
}