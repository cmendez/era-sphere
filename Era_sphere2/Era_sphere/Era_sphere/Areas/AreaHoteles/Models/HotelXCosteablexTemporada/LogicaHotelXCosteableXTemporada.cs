using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXCosteableXTemporadaNM
{
    public class LogicaHotelXCosteableXTemporada
    {
        EraSphereContext hxcxt_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXCosteableXTemporada> database_table;
        private int hotelID;

        public LogicaHotelXCosteableXTemporada(int id)
        {
            this.hotelID = id;
            database_table = new DBGenericQueriesUtil<HotelXCosteableXTemporada>(hxcxt_context, hxcxt_context.hxchts);
        }


        public List<HotelXCosteableXTemporadaView> retornarCosteablesXTemporada()
        {
            List<HotelXCosteableXTemporada> hxcxts = database_table.retornarTodos();
            hxcxts.Where(e => e.hotelID == hotelID);
            List<HotelXCosteableXTemporadaView> hctvs = new List<HotelXCosteableXTemporadaView>();
            foreach (HotelXCosteableXTemporada e in hxcxts)
            {
                hctvs.Add(new HotelXCosteableXTemporadaView(e));
            }
            return hctvs;
        }
    }
}