using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaProveedores.Models
{
    public class ProveedorContext:DbContext
    {
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<EstadoProveedor> estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
                        
        
        public void Seed()
        {
            try
            {
                if (estados.Count() != 0) return;
            }
            catch (Exception) { }

            var _estados = new List<EstadoProveedor>
            {
                new EstadoProveedor{nombre = "activo", ID = 1},
                new EstadoProveedor{nombre = "inactivo", ID = 2}
            };
            foreach (var e in _estados)
                estados.Add(e);
            SaveChanges();
           
        }

    }


}