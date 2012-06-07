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
        public DbSet<HabitacionXReserva> habitacion_x_reservas { get; set; }

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
        public void seedHabitaciones()
        {
            new List<Habitacion>()
            {
                new Habitacion(){ detalle = "Hab1", tipoHabitacionID = 1, tipoHabitacion = tipos_habitacion.Find(1), estadoID = 1, estado = estado_espacio_rentable.Find(1), pisoID = 1, piso = pisos.Find(1)},
                new Habitacion(){ detalle = "Hab2", tipoHabitacionID = 2, tipoHabitacion = tipos_habitacion.Find(2), estadoID = 1, estado = estado_espacio_rentable.Find(1), pisoID = 1, piso = pisos.Find(1)},
                new Habitacion(){ detalle = "Hab3", tipoHabitacionID = 1, tipoHabitacion = tipos_habitacion.Find(3), estadoID = 1, estado = estado_espacio_rentable.Find(1), pisoID = 1, piso = pisos.Find(1)},

            }.ForEach(p => this.habitaciones.Add(p));
            SaveChanges();
        }
        public void seedComodidades()
        {
            List<Comodidad> cs = new List<Comodidad>()
            {
                new Comodidad(){descripcion="comodidad1"},
                new Comodidad(){descripcion="comodidad2"},
                new Comodidad(){descripcion="comodidad3"}
            };
            foreach(Comodidad c in cs) comodidades.Add(c);
            SaveChanges();
        }
    }
}
