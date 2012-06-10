using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Piso> pisos { get; set; }
        public void seedPisos()
        {
            List<Piso> ps = new List<Piso>()
            {
                new Piso(){descripcion="piso1",codigo_piso ="p01",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="piso2",codigo_piso ="p02",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="piso3",codigo_piso ="p03",hotelID=1, hotel = hoteles.Find(1)}
            };
            foreach (Piso p in ps) pisos.Add(p);
            SaveChanges();
        }
    }
}