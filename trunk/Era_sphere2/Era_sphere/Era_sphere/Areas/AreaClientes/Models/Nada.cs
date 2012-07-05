using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class Nada
    {
        public List<ReciboLinea> recibos { get; set; }
        public string cliente { get; set; }
        public string estado { get; set; }
        public string puntos { get; set; }
    }
}