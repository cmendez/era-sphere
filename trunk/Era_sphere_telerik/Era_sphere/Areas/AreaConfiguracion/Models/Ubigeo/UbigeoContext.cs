﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class UbigeoContext : DbContext
    {
        public DbSet<Pais> paises;
        public DbSet<Ciudad> ciudades;
    }
}