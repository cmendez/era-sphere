using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXCosteable
{
    public class LogicaHotelXCosteable : InterfazLogicaHotelXCosteable
    {
        private int hotelID;

        public LogicaHotelXCosteable(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public List<HotelXCosteableXTemporadaView> retornarCosteables()
        {
            return null;
        }
    }
}