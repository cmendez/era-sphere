using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class HabitacionContext:DbContext
    {
        public DbSet<Habitacion> habitaciones { get; set; }
    }
}