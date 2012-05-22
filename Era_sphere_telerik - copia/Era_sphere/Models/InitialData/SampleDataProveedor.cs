using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaProveedores.Models;

namespace Era_sphere.Models.InitialData
{
    public class SampleDataProveedor : DropCreateDatabaseIfModelChanges<ProveedorContext>
    {
        protected override void Seed(ProveedorContext context)
        {
            base.Seed(context);

            var estados = new List<EstadoProveedor>
            {
              new EstadoProveedor{ ID= 1 , nombre ="activo" },
              new EstadoProveedor{ ID=2 , nombre ="inactivo"}
            };

            estados.ForEach( e => context.estados.Add(e));
            context.SaveChanges();
        }
    }
}