using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM
{
    public class LogicaHotelXPreciableXTemporada
    {

        //logicahpt.retornarPreciablesXTemporada()
        //logicahpt.eliminarPreciableXTemporada(preciableXTemporada_id);
        //logicahpt.modificarCosteableXTemporada(p);
        //logicahpt.agregarPreciableXTemporada(hpt_view);



        EraSphereContext hxpxt_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXPreciableXTemporada> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaHotelXPreciableXTemporada()
        {
            database_table = new DBGenericQueriesUtil<HotelXPreciableXTemporada>(hxpxt_context, hxpxt_context.hxpxts);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxpxt_context, hxpxt_context.hoteles);
        }


        public List<HotelXPreciableXTemporadaView> retornarPreciablesXTemporada(int hid)
        {
            List<HotelXPreciableXTemporada> hxpxts = database_table.retornarTodos();
            hxpxts.Where(e => e.hotelID == hid);
            List<HotelXPreciableXTemporadaView> hptvs = new List<HotelXPreciableXTemporadaView>();
            foreach (HotelXPreciableXTemporada e in hxpxts)
            {
                hptvs.Add(new HotelXPreciableXTemporadaView(e));
            }
            return hptvs;
        }

        public void agregarPreciableXTemporada(int id, HotelXPreciableXTemporadaView pxtv)
        {
            database_table.agregarElemento(pxtv.deserializa());
        }

        public void eliminarPreciableXTemporada(int id, int preciableXTemporada_id)
        {
            database_table.eliminarElemento(preciableXTemporada_id);
            return;
        }

        public void modificarPreciableXTemporada(int id, HotelXPreciableXTemporadaView pxtv)
        {
            HotelXPreciableXTemporada hpt = pxtv.deserializa();
            database_table.modificarElemento(hpt, hpt.ID);
            return;            
        }

        public string retornaNombreHotel(int hotel_id)
        {
            Hotel hotel_perteneciente = database_table_hotel.retornarUnSoloElemento(hotel_id);
            return hotel_perteneciente.razon_social;
        }
    }
}