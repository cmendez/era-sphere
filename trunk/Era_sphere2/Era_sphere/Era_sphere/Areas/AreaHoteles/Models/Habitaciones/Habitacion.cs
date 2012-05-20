    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Habitacion: EspacioCargable
    {
        
        public string detalle { get; set; }

        public string estado { get; set; }

       // public ICollection<HabitacionXComodidad> habitacionXcomodidad { get; set; }

        public string tipoHabitacion { get; set; }
    }
}