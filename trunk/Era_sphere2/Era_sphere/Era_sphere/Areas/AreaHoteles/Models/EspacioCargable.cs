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
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Piso")]
        public Piso piso { get; set; }
    }
}