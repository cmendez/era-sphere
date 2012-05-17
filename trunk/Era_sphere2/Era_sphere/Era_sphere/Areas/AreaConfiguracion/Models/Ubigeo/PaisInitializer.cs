using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.Configuracion.Models;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class PaisInitializer : DropCreateDatabaseIfModelChanges<PaisDBContext>
    {
        protected override void Seed(PaisDBContext context)
        {
            base.Seed(context);
        }

    }
}