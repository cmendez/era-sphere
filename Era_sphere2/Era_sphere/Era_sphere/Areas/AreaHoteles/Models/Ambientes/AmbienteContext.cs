
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public class AmbienteContext: DbContext
    {
        public DbSet<Ambiente> ambientes { get; set; }
    }
}