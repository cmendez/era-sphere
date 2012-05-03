using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.ApiConfiguracion.Models
{

    public class CadenaContext : DbContext
    {
        public DbSet<Cadena> cadenas { get; set; }
    }
}