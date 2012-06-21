using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class ReciboLineaXServicio : DBable
    {
        public int recibo_lineaID { get; set; }
        public int servicioID { get; set; }
    }
}