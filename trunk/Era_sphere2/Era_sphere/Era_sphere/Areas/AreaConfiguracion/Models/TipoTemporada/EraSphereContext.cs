using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Temporada> temporadas { get; set; }
        public DbSet<TipoTemporada> tipostemporada { get; set; }
    }
}
