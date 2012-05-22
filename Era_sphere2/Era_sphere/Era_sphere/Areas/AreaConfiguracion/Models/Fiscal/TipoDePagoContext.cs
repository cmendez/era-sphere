using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class TipoDePagoContext : DbContext
    {
        public DbSet<TipoDePago> tipo_de_pagos { get; set; }
    }

    public class TipoDePagoContextInitializer : DropCreateDatabaseAlways<TipoDePagoContext>
    {
        protected override void Seed(TipoDePagoContext context)
        {
            new List<TipoDePago>
            {
                new TipoDePago {Id=1, Descripcion="Efectivo"},
                new TipoDePago {Id=2,Descripcion="Con Tarjeta Visa"},
                new TipoDePago {Id=3,Descripcion="Con Tarjeta MasterCard"}
            }.ForEach(b => context.tipo_de_pagos.Add(b));

            base.Seed(context);
        }
    }
}