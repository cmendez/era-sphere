using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaCargos.Models
{
    public abstract class Preciable : DBable
    {
        //public decimal precio { get; set; }
        //public bool precio_fijado { get; set; }

        //sobreescribe este metodo si el precio se calcula de alguna manera diferente
        public List<ReciboLinea> generarReciboLineas()
        {
            return new List<ReciboLinea> { new ReciboLinea { detalle = "Este es un costeable cualquiera", precio = 0, pagado = false, unidades = 1 } };
        }
    }
}