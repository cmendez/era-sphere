using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaCargos.Models
{
    public abstract class Preciable :DBable
    {
        public string descripcion { get; set; }
    }
}