using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class EstadoEspacioRentableInitializer : DropCreateDatabaseIfModelChanges<EraSphereContext>
    {
        public void Seed(EraSphereContext context)
        {
            EstadoEspacioRentable estado_habitacion_1 = new EstadoEspacioRentable { descripcion="libre"};
            EstadoEspacioRentable estado_habitacion_2 = new EstadoEspacioRentable { descripcion = "ocupado" };
            context.estado_espacio_rentable.Add(estado_habitacion_1);
            context.estado_espacio_rentable.Add(estado_habitacion_2);
            context.SaveChanges();
        }
    }
    
}