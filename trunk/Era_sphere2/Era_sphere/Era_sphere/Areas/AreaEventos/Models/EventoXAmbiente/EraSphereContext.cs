using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<EventoXAmbiente> eventoXAmbientes { get; set; }

    }
}