using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class PisoContext:DbContext
    {
        public DbSet<Piso> pisos { get; set; }
    }
}