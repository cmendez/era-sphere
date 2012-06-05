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
            proveedores.Add(p);

        }

        void seedProductos() {
            for (int i = 0; i < 10; i++) {
                productos.Add(new Producto { ID = i , descripcion = "Producto " + i } );
            }

        }
    }
}
