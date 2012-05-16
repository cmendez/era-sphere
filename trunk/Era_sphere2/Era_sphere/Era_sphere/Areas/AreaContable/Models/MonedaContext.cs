using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class MonedaContext:DbContext
    {
        public DbSet<Moneda> monedas { get; set; }
        public DbSet<Pais> pais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            try
            {
                if (monedas.Count() != 0) return;
            }
            catch (Exception) { }

            var _monedas = new List<Moneda>
            {
                new Moneda{moneda_descripcion="Soles",simbolo="S/. ",ID=1},
                new Moneda{moneda_descripcion="Dolares",simbolo="USS/. ",ID=2},
            };

            foreach (var m in _monedas)
                monedas.Add(m);
            SaveChanges();

            try
            {
                if (pais.Count() != 0) return;
            }
            catch (Exception) { }

            var _pais = new List<Pais>
            {
                new Pais{nombrePais="Peru",ID=1},
                new Pais{nombrePais="Otros",ID=2},
            };

            foreach (var p in _pais)
                pais.Add(p);
            SaveChanges();

        }
    }
}