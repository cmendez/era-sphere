using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class Pais : DBable
    {
        public string nombrePais { set; get; }
    }
}