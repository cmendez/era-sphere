using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class HabitacionXComodidad:DBable
    {
        public Habitacion habitacion;
        public Comodidad comodidad;
    }

}