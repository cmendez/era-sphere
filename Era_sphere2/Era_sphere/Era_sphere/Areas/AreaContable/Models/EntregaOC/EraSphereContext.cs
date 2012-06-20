﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<EntregaOC> entregas_oc { get; set; }
        public DbSet<EOCLinea> entrega_oc_linea { get; set; }
    
    }
}
