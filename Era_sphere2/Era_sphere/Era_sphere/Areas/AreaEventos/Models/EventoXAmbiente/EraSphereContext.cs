﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<EventoXAmbiente> eventoXAmbientes { get; set; }

    }
}