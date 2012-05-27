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
        }
    }

    public class EraSphereContextInitializer : DropCreateDatabaseAlways<EraSphereContext>{
        protected override void Seed(EraSphereContext context){
            context.seed();
        }
    }
}
