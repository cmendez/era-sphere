using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class EstadoHabitacion:DBable
    {   //libre reservado ocupada
        public string descripcion { get; set; }
        public ICollection<Habitacion> lista_habitaciones { get; set; }
    }
}