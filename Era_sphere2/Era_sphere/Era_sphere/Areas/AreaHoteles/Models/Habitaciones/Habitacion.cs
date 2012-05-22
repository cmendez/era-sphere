    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Habitacion: EspacioCargable
    {
         
        public string detalle { get; set; }

        public string estado { get; set; }

        public ICollection<Comodidad> comodidades { get; set; }

        public TipoHabitacion tipoHabitacion { get; set; }
    }
}