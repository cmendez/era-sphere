using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ProveedorContext : DbContext
    {
        public DbSet<Proveedor> proveedores { get; set; }
    }
}