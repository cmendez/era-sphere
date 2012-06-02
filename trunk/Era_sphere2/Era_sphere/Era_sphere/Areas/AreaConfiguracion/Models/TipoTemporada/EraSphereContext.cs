using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Temporada> temporadas { get; set; }
        public DbSet<TipoTemporada> tipostemporada { get; set; }

        public void seedTipoTemporadas()
        {
            List<TipoTemporada> tts = new List<TipoTemporada>
            {
                new TipoTemporada { descripcion = "San Valentin" },
                new TipoTemporada { descripcion = "Fiestas Patrias" },
                new TipoTemporada { descripcion = "Navidad" }
            };
            foreach(TipoTemporada tt in tts) tipostemporada.Add(tt);
            SaveChanges();
        }

        public void seedTemporadas()
        {
            List<Temporada> ts = new List<Temporada>
            {
                new Temporada { descripcion = "San Valentin '12", fecha_inicio = DateTime.Parse("2012-02-09"), fecha_fin = DateTime.Parse("2012-02-14"), tipotemporadaID = 1 },
                new Temporada { descripcion = "San Valentin '13", fecha_inicio = DateTime.Parse("2013-02-09"), fecha_fin = DateTime.Parse("2013-02-14"), tipotemporadaID = 1 },
                new Temporada { descripcion = "Navidad '09", fecha_inicio = DateTime.Parse("2009-12-21"), fecha_fin = DateTime.Parse("2009-12-25"), tipotemporadaID = 3 }
            };
            foreach (Temporada t in ts) temporadas.Add(t);
            SaveChanges();
        }
    }
}
