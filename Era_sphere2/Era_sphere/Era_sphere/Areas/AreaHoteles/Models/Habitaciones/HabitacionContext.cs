﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HabitacionContext:DbContext
    {
        public DbSet<Habitacion> habitaciones { get; set; }
        public DbSet<Comodidad> comodidades { get; set; }
    }
}