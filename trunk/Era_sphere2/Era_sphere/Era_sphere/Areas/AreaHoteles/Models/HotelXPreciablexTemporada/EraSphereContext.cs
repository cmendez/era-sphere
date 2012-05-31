using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Data.Entity;

using Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM;


namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<HotelXPreciableXTemporada> hxpxts { get; set; }
    }
}