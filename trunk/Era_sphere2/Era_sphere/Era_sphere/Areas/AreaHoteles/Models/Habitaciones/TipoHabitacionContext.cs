using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacionContext:DbContext
    {
        public DbSet<TipoHabitacion> tipos_habitacion { get; set; }
        public DbSet<Comodidad> comodidades { get; set; }
    }
}