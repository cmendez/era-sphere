using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class ReservaContext: DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
    }
}