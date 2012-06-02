using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Objects;
using System.Data;

namespace Era_sphere.Generics
{
    
    public partial class EraSphereContext : DbContext
    {
        public void seed(){
            seedHotel();
            seedUbigeo();
            seedEstadoEspacioRentable();
            seedEstadoCliente();
            seedTipoPersona();
            seedServicios();
            seedTipoTemporadas();
            seedTemporadas();
        }

        public DbSet<TipoPersona> tipos_personas { get; set; }
        public void seedTipoPersona()
        {
            TipoPersona natural = new TipoPersona { ID = 1, descripcion = "Natural" };
            TipoPersona juridico = new TipoPersona { ID = 2, descripcion = "Juridico" };
            tipos_personas.Add(natural);
            tipos_personas.Add(juridico);
            SaveChanges();
        }

    }

    public class EraSphereContextInitializer : DropCreateDatabaseAlways<EraSphereContext>{
        protected override void Seed(EraSphereContext context){
            context.seed();
        }
    }
}
