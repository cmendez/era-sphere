using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaHoteles.Models;


namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Ambiente> ambientes { get; set; }

        public void seedAmbientes()
        {
            List<Ambiente> ambs = new List<Ambiente>
            {
                new Ambiente { descripcion = "Ambiente para bodas", capacidad_maxima = 200, num_niveles = 2, detalle = "Destinado para casaminetos", precio = 50, pisoID = 1, /*piso = (new EraSphereContext()).pisos.Find(1),*/ estadoID = 1/*, estado = (new EraSphereContext()).estado_espacio_rentable.Find(1)*/},
                new Ambiente { descripcion = "Ambiente reuniones", capacidad_maxima = 80, num_niveles = 2, detalle = "Destinado para reuniones pequeñas", precio = 35, pisoID = 2, /*piso = (new EraSphereContext()).pisos.Find(2),*/ estadoID = 1/*, estado = (new EraSphereContext()).estado_espacio_rentable.Find(1)*/},

                new Ambiente { descripcion = "Ambiente musical", capacidad_maxima = 100, num_niveles = 3, detalle = "Destinado para conciertos", precio = 35, pisoID = 5, /*piso = (new EraSphereContext()).pisos.Find(5),*/ estadoID = 1/*, estado = (new EraSphereContext()).estado_espacio_rentable.Find(1)*/},
            };
            foreach (Ambiente amb in ambs) ambientes.Add(amb);
            SaveChanges();
        }
    }
}
