using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Generics
{
    public abstract class DBable
    {
        [Key]
        public int ID { get; set; }
        bool eliminado { get; set; }
    }
}
