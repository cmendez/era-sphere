using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ProductoContext : DbContext
    {
        public DbSet<Moneda> productos { get; set; }
    }
}