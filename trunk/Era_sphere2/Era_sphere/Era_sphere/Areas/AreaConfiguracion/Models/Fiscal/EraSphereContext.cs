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
    }
}
