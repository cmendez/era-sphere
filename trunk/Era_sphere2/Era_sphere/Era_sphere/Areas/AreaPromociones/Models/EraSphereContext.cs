using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaPromociones.Models;


namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Promocion> promociones { get; set; }
        public DbSet<RelacionPromocion> relacionespromocion { get; set; }

        public void seedRelacionesPromocion()
        {
            List<RelacionPromocion> rps = new List<RelacionPromocion>
            {
                new RelacionPromocion { ID = 1, descripcion = "Evento" },
                new RelacionPromocion { ID = 2, descripcion = "Reserva" }
            };
            foreach (RelacionPromocion rp in rps) relacionespromocion.Add(rp);
            SaveChanges();
        }


    }
}
