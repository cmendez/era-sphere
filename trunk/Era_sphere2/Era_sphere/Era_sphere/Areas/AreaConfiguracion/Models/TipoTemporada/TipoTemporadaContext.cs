using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.TipoTemporada
{
    public class TipoTemporadaContext:DbContext
    {
        public DbSet<TipoTemporada> tipostemporada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}