using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Evento> eventos { get; set; }
        public DbSet<EstadoEvento> estados_evento { get; set; }
        void seedEvento()
        {
            estados_evento.Add(new EstadoEvento { ID = 1, descripcion = "Creado" });
            estados_evento.Add(new EstadoEvento { ID = 2, descripcion = "Registrado" });
            estados_evento.Add(new EstadoEvento { ID = 3, descripcion = "PParcial" });
            estados_evento.Add(new EstadoEvento { ID = 4, descripcion = "PTotal" });
            estados_evento.Add(new EstadoEvento { ID = 5, descripcion = "Cancelado" });
        }
        
    }
}