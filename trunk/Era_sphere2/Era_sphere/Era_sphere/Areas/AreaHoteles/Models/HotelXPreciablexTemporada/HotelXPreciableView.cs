using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM
{
    public class HotelXPreciableView
    {

        public HotelXPreciableView()
        {
        }

        public int preciableID { get; set; }

        public Preciable preciable { get; set; }
    }
}