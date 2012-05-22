using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Generics
{
    public abstract class DBable
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
    }
}
