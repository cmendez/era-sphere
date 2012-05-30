using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class ReciboLinea: DBable
    {
        [ForeignKey("recibo")]
        public int reciboID { get; set; }
        public Recibo? recibo { get; set; }

        public int espacio_rentableID { get; set; }

        public decimal precio { get; set; }

        public string detalle { get; set; }
        public int unidades { get; set; }
        public bool pagado { get; set; }
    }
}