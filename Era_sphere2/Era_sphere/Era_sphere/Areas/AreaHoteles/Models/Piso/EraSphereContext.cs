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
                new Piso(){descripcion="Primer piso",codigo_piso ="P01",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Segundo piso",codigo_piso ="P02",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Tercer piso",codigo_piso ="P03",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Cuarto piso",codigo_piso ="P04",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Primer piso",codigo_piso ="P01",hotelID=2, hotel = hoteles.Find(2)},
                new Piso(){descripcion="Segundo piso",codigo_piso ="P02",hotelID=2, hotel = hoteles.Find(2)},
                new Piso(){descripcion="Tercer piso",codigo_piso ="P03",hotelID=2, hotel = hoteles.Find(2)},
            };
            foreach (Piso p in ps) pisos.Add(p);
            SaveChanges();
        }
    }
}