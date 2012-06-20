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
                //new Ambiente { descripcion = "San Valentin" },
                //new Ambiente { descripcion = "Fiestas Patrias" },
                //new Ambiente { descripcion = "Navidad" }
            };
            foreach (Ambiente amb in ambs) ambientes.Add(amb);
            SaveChanges();
        }
        
    }
}
