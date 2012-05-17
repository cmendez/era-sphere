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
        [DisplayName("Detalles")]
        public string detalles { get; set; }

        public enum Estado
        {
            ocupada,
            libre,
            inactiva
        }

        [DisplayName("Estado")]
        public Estado estado { get; set; }

       // public ICollection<HabitacionXComodidad> habitacionXcomodidad { get; set; }

        [DisplayName("Tipo de habitacion")]
        public TipoHabitacion tipohabitacion { get; set; }
    }
}