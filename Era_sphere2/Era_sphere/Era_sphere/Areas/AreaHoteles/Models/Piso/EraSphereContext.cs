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
                new Piso(){descripcion="Piso 001",codigo_piso ="P001",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Piso 002",codigo_piso ="P002",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Piso 003",codigo_piso ="P003",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Piso 004",codigo_piso ="P004",hotelID=1, hotel = hoteles.Find(1)},
                new Piso(){descripcion="Piso 001",codigo_piso ="P001",hotelID=2, hotel = hoteles.Find(2)},
                new Piso(){descripcion="Piso 002",codigo_piso ="P002",hotelID=2, hotel = hoteles.Find(2)},
                new Piso(){descripcion="Piso 003",codigo_piso ="P003",hotelID=2, hotel = hoteles.Find(2)},
            };
            foreach (Piso p in ps) pisos.Add(p);
            SaveChanges();
        }
    }
}