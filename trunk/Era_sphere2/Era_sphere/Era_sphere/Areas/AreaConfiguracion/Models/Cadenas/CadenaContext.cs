using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Cadenas
{

    public class CadenaContext : DbContext
    {
        public DbSet<Cadena> cadenas { get; set; }
    }
}