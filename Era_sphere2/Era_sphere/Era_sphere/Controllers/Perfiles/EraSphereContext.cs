using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Perfil> perfiles { get; set; }
        public void seedPerfil() {
            Perfil perfil = new Perfil
            {
                descripcion = "superadmin",
                ID = 1,
                listaVisibilidad = "11111111",
                nombrePerfil = "superadmin"
            };
            perfiles.Add(perfil);
            SaveChanges();
        }
    }
}
