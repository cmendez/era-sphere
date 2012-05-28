using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaContable.Models.Producto
{
    public class ProductoContext
    {
        public DbSet<Producto> productos { get; set; }
    }
}