using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext:DbContext
    {
        public DbSet<TipoServicio> tipo_servicios { get; set; }
        public DbSet<Servicio> servicios { get; set; }
        public DbSet<TipoServicioXHotel> tipo_servicioxhoteles { get; set; }
        public DbSet<ProductoXServicio> productoxservicios { get; set; }
        public DbSet<ServicioXReserva> servicioxreservas { get; set; }

        public void seedServicios()
        {
            List<Servicio> ss = new List<Servicio>
            {
                new Servicio { descripcion = "Botella 1/2L Coca Cola" },
                new Servicio { descripcion =  "Desayuno Premium"}
            };

            foreach (Servicio s in ss) servicios.Add(s);
            this.SaveChanges();
            
        }
    }
}