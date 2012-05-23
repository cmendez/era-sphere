using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public abstract class EspacioCargable : EspacioRentable
    {
        [DisplayName("Piso")]
        public int pisoID { get; set; }
        public Piso piso { get; set; }  
    }
}