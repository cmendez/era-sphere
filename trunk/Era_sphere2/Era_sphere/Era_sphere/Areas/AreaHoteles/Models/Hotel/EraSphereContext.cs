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
        public DbSet<Hotel> hoteles { get; set; }
        void seedHotel()
        {
            //Hotel hotel = new Hotel() { descripcion = "Hotel Buena Vista Lima", razon_social = "MalaVista S.A.", reg_id = "RUC", nroreg_id = "01234567891", direccion = "Av. Los Mares 744 San Isidro", telefono_1 = "745-8969", pais = this.paises.Find(12), ciudad = this.ciudades.Find(28), provincia = this.provincias.Find(8) };
            Hotel hotel = new Hotel() { descripcion = "Hotel Buena Vista Lima", razon_social = "MalaVista S.A.", reg_id = "RUC", nroreg_id = "01234567891", direccion = "Av. Los Mares 744 San Isidro", telefono_1 = "745-8969", paisID = 12, ciudadID = 28, provinciaID = 8 };
            hoteles.Add(hotel);
            SaveChanges();
        }
    }
}
