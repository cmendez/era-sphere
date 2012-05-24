using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<EstadoEspacioRentable> estado_espacio_rentable { get; set; }

        public void seedEstadoEspacioRentable()
        {
            EstadoEspacioRentable estado_habitacion_1 = new EstadoEspacioRentable { descripcion = "libre" };
            EstadoEspacioRentable estado_habitacion_2 = new EstadoEspacioRentable { descripcion = "ocupado" };
            estado_espacio_rentable.Add(estado_habitacion_1);
            estado_espacio_rentable.Add(estado_habitacion_2);
            SaveChanges();
        }
    }
}
