using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class MonedaContext : DbContext
    {
        public DbSet<Moneda> monedas { get; set; }
    }
}