using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class Recibo: DBable
    {
        public ICollection<ReciboLinea> recibo_lineas { get; set; }

        [ForeignKey("cliente")]
        public int clienteID { get; set; }
        public Cliente cliente { get; set; }
        public DateTime? fecha { get; set; }
        public decimal precio_total { get; set; }
        public decimal precio_tarjeta { get; set; }
        public decimal precio_contado { get; set; }

        //0 es boleta y 1 es factura
        public int tipo { get; set; }

    }
}