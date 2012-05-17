using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HotelContext:DbContext
    {
        public DbSet<Hotel> hoteles { get; set; }
    }
}