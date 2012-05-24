using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class TipoDePagoContext : DbContext
    {
        public DbSet<TipoDePago> tiposdepagos { get; set; }
    }
}