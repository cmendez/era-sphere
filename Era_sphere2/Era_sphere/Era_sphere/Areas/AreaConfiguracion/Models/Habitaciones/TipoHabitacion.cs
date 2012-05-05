using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class TipoHabitacion: EspacioRentable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Capacidad Maxima")]
        public int cap_max_personas { get; set; }

        public ICollection<HabitacionXComodidad> habitacionXcomodidad { get; set; }

    }
}