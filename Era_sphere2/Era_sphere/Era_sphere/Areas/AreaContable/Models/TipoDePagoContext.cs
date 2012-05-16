using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class TipoDePagoContext : DbContext
    {
        public DbSet<Moneda> monedas { get; set; }
        public DbSet<PagoTarjeta> tarjetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected void Seed()
        {
            try
            {
                if (tarjetas.Count() != 0) return;
            }
            catch (Exception) { }

            var _tarjetas = new List<PagoTarjeta>
            {
                new PagoTarjeta{Metodo_pago="Visa",ID=1},
                new PagoTarjeta{Metodo_pago="MasterCard",ID=2},
                new PagoTarjeta{Metodo_pago="American Express",ID=3}
            };

            foreach (var t in _tarjetas)
                tarjetas.Add(t);
            SaveChanges();

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
        }
    }
}