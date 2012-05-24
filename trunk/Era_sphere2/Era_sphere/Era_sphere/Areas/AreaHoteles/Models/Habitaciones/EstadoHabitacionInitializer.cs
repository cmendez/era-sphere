using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class EstadoHabitacionInitializer : DropCreateDatabaseIfModelChanges<EraSphereContext>
    {
        public void Seed(EraSphereContext context)
        {
            EstadoHabitacion estado_habitacion_1 = new EstadoHabitacion { descripcion="libre"};
            EstadoHabitacion estado_habitacion_2 = new EstadoHabitacion { descripcion = "reservado" };
            EstadoHabitacion estado_habitacion_3 = new EstadoHabitacion { descripcion = "ocupado" };
            context.estado_habitacion.Add(estado_habitacion_1);
            context.estado_habitacion.Add(estado_habitacion_2);
            context.estado_habitacion.Add(estado_habitacion_3);
            context.SaveChanges();
        }
    }
    
}