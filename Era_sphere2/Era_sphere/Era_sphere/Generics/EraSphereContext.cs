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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seedHotel(modelBuilder);
            seedUbigeo(modelBuilder);

        }
    }
}
