using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Producto
{
    public class Producto:DBable
    {
        public String descripcion { get; set; }
    }
}