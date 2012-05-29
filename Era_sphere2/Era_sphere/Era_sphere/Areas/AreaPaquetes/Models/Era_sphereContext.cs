using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaPaquetes.Models
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet <Paquete> paquetes { get; set; }
    }
}