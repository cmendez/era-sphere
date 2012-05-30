using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaCargos.Models
{
    public abstract class Costeable : DBable
    {
        public virtual string nombre { get; set; }
        public decimal precio { get; set; }
    }
}