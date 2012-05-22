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

    public class MonedaContextInitializer : DropCreateDatabaseAlways<MonedaContext>
    {
        protected override void Seed(MonedaContext context)
        {
            new List<Moneda>
            {
                new Moneda {Id=1, Descripcion="Nuevos Soles", simbolo="S/. "},
                new Moneda {Id=2,Descripcion="Dolares Americanos", simbolo="USS/. "}
            }.ForEach(b => context.monedas.Add(b));

            base.Seed(context);
        }
    }
}