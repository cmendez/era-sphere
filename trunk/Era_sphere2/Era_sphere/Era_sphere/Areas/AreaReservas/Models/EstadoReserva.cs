using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class EstadoReserva:DBable
    {
        public string descripcion { get; set; }
        public ICollection<Reserva> lista_reservas { get; set; }
    }
}