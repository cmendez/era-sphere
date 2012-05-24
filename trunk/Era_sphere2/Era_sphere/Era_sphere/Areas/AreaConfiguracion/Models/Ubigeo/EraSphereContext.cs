using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Pais> paises { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Provincia> provincias { get; set; }
    }
}
