using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LineaProducto : DBable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        //public ICollection<Producto> productos { get; set; }
    }
}