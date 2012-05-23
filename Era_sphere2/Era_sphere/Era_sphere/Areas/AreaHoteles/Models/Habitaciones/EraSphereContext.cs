using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Habitacion> habitaciones { get; set; }
        public DbSet<Comodidad> comodidades { get; set; }
        public DbSet<TipoHabitacion> tipos_habitacion { get; set; }
        public DbSet<EstadoHabitacion> estado_habitacion { get; set; }
    }
}
