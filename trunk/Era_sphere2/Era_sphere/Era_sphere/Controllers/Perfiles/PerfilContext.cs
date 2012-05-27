using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Perfiles
{
    public class PerfilContext: DbContext
    {
        public DbSet<Perfil> perfiles { get; set; }
    }
}