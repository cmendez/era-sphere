using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM
{
    public class LogicaHotelXProducto
    {

        //logicahpt.retornarProductos()
        //logicahpt.eliminarProducto(servicioXTemporada_id);
        //logicahpt.modificarCosteableXTemporada(p);
        //logicahpt.agregarProducto(hpt_view);



        EraSphereContext hxp_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXProducto> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaHotelXProducto()
        {
            database_table = new DBGenericQueriesUtil<HotelXProducto>(hxp_context, hxp_context.hxps);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxp_context, hxp_context.hoteles);
        }


        public List<HotelXProductoView> retornarProductos(int hid)
        {
            List<HotelXProducto> hxps = database_table.retornarTodos();
            hxps = hxps.Where(e => e.hotelID == hid).ToList();
            List<HotelXProductoView> hxpvs = new List<HotelXProductoView>();
            foreach (HotelXProducto e in hxps)
            {
                hxpvs.Add(new HotelXProductoView(e));
            }
            return hxpvs;
        }

        public void agregarProducto(int id, HotelXProductoView hxpv)
        {
            database_table.agregarElemento(hxpv.deserializa());
        }

        public void eliminarProducto(int hotelXProductoID)
        {
            database_table.eliminarElemento_logico(hotelXProductoID);
            return;
        }

        public void modificarProducto(int id, HotelXProductoView hxpv)
        {
            HotelXProducto hxp = hxpv.deserializa();
            database_table.modificarElemento(hxp, hxp.ID);
            return;
        }

        public string retornaNombreHotel(int hotel_id)
        {
            Hotel hotel_perteneciente = database_table_hotel.retornarUnSoloElemento(hotel_id);
            return hotel_perteneciente.razon_social;
        }

        internal System.Web.Mvc.IView retornarHotelXProductos(int id)
        {
            throw new NotImplementedException();
        }
    }
}