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

        public void seedTipoHabitaciones()
        {
            List<TipoHabitacion> ths = new List<TipoHabitacion>()
            {
                new TipoHabitacion() { descripcion="Simple", cap_max_personas=2, costo_base = 80.00M },
                new TipoHabitacion() { descripcion="Doble", cap_max_personas=4, costo_base = 120.00M },
                new TipoHabitacion() { descripcion="Deluxe", cap_max_personas=2, costo_base = 130.00M },
                new TipoHabitacion() { descripcion="Suite Presidencial", cap_max_personas=3, costo_base = 250.00M }
            };
            foreach (TipoHabitacion th in ths) tipos_habitacion.Add(th);
            SaveChanges();

        }
    }
}
