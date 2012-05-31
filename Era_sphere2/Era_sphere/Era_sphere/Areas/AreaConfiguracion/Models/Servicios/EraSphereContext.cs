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
    }
}