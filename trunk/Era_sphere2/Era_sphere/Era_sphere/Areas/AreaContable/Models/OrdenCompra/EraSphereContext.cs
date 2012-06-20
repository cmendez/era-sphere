using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;
using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<EstadoOC> estados_ocompra { get; set; }
        public DbSet<OrdenCompra> ordenes_compra { get; set; }
        public DbSet<OCompraLinea> ordenes_clinea { get; set; }
        void crear_orden_compra(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<OCompraLinea>().HasRequired(e => e.orden_compra)
                                                    .WithMany(t => t.productos)
                                                    .HasForeignKey(e => e.orden_compraID)
                                                    .WillCascadeOnDelete(false);
        }
        void seedOrdenCompra() {
            estados_ocompra.Add(new EstadoOC { ID = 1, descripcion = "Creado" });
            estados_ocompra.Add(new EstadoOC { ID = 2, descripcion = "Registrado" });
            estados_ocompra.Add(new EstadoOC { ID = 3, descripcion = "Aceptado" });
            estados_ocompra.Add(new EstadoOC { ID = 4, descripcion = "Atendido" });
            estados_ocompra.Add(new EstadoOC { ID = 5, descripcion = "Cancelado" });
            estados_ocompra.Add(new EstadoOC { ID = 6, descripcion = "Pagado" });
        }
    }
}
