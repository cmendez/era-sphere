using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacion: EspacioRentable
    {

        public string descripcion { get; set; }

        public int cap_max_personas { get; set; }

        public ICollection<Comodidad> comodidades { get; set; }

    }
}