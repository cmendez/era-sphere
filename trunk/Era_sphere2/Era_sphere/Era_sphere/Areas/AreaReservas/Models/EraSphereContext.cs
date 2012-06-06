using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaReservas.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<EstadoReserva> estados_reserva{ get; set; }

        public void seedEstadoReserva()
        {
            EstadoReserva estado_reserva_1 = new EstadoReserva { descripcion = "Sin Check-in" };
            EstadoReserva estado_reserva_2 = new EstadoReserva { descripcion = "CheckedIn" };
            EstadoReserva estado_reserva_3 = new EstadoReserva { descripcion = "CheckedOut" };
            EstadoReserva estado_reserva_4 = new EstadoReserva { descripcion = "Anulada" };
            estados_reserva.Add(estado_reserva_1);
            estados_reserva.Add(estado_reserva_2);
            estados_reserva.Add(estado_reserva_3);
            estados_reserva.Add(estado_reserva_4);
            SaveChanges();

        }
    }
}
