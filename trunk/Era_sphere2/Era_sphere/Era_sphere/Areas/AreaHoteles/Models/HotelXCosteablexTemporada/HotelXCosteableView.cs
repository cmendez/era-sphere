using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXCosteablexTemporada
{
    public class HotelXCosteableView
    {

        public HotelXCosteableView()
        {
        }

        public int costeableID { get; set; }

        public Costeable costeable { get; set; }
    }
}