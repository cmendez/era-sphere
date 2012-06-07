using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaContable.Models.Ordenes;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Moneda> monedas { get; set; }
        public DbSet<TipoDePago> tiposdepagos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Orden> ordenes { get; set; }
        public DbSet<OrdenLinea> ordeneslineas { get; set; }
        public DbSet<proveedor_x_producto> p_x_p { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<proveedor_x_producto>().HasRequired(e => e.proveedor)
                                                    .WithMany(t => t.productos)
                                                    .HasForeignKey(e => e.proveedorID)
                                                    .WillCascadeOnDelete(false);
        }
        void seedProveedores() {
            Proveedor p = new Proveedor
            {
                ID = 1,
                razon_social = "Proveedor 1",
                ruc = "21234567890",
                telefono = "12312312",
                correo = "a@b.c",
                direccion = "direccion 1 ",
                persona_contacto = "Persona 1"
            };
         
            proveedores.Add(
                new Proveedor { 
                    ID = 2,
                    razon_social = "Proveedor 2",
                    ruc = "123123123",
                    telefono = "1212112",
                    correo = "ff@g.g",
                    direccion = "direccion 2",
                    persona_contacto = "Persona 2"
                }
          );
            p.productos = new List<proveedor_x_producto>();
            foreach (var x in productos) {
                proveedor_x_producto pp = new proveedor_x_producto
                {
                    ID = x.ID,
                    precio_unitario = x.ID + 0.5,
                    proveedor = p,
                    producto = x
                };
                p_x_p.Add(pp);
                p.productos.Add(pp);
            }
            proveedores.Add(p);
        }

        void seedProductos() {
            for (int i = 0; i < 10; i++) {
                productos.Add(new Producto { ID = ( i + 1 ) , descripcion = "Producto " + ( i + 1 ) } );
            }

        }

        void seedProvXProd()
        {
            List<proveedor_x_producto> pxps = new List<proveedor_x_producto>
            {
                new proveedor_x_producto { proveedorID = 1 , productoID = 1 , precio_unitario = 2.80 },
                new proveedor_x_producto { proveedorID = 1 , productoID = 3 , precio_unitario = 14.82 },
                new proveedor_x_producto { proveedorID = 1 , productoID = 4 , precio_unitario = 0.53 }
            };
            foreach(proveedor_x_producto pxp in pxps) p_x_p.Add(pxp);
            SaveChanges();

        }
    }
}
