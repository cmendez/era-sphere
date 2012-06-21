using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM
{
    public class LogicaHotelXTipoServicioXTemporada
    {

        //logicahpt.retornarServiciosXTemporada()
        //logicahpt.eliminarServicioXTemporada(servicioXTemporada_id);
        //logicahpt.modificarCosteableXTemporada(p);
        //logicahpt.agregarServicioXTemporada(hpt_view);



        public EraSphereContext hxsxt_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXTipoServicioXTemporada> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaHotelXTipoServicioXTemporada()
        {
            database_table = new DBGenericQueriesUtil<HotelXTipoServicioXTemporada>(hxsxt_context, hxsxt_context.hxsxts);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxsxt_context, hxsxt_context.hoteles);
        }


        public List<HotelXTipoServicioXTemporadaView> retornarTipoServiciosXTemporada(int hid)
        {
            List<HotelXTipoServicioXTemporada> hxsxts = database_table.retornarTodos();
            hxsxts = hxsxts.Where(e => e.hotelID == hid).ToList();
            List<HotelXTipoServicioXTemporadaView> hstvs = new List<HotelXTipoServicioXTemporadaView>();
            foreach (HotelXTipoServicioXTemporada e in hxsxts)
            {
                e.tipo_servicio = hxsxt_context.tipo_servicios.Find(e.tipo_servicioID);
                e.temporada = hxsxt_context.temporadas.Find(e.temporadaID);
                e.temporada.tipotemporada = hxsxt_context.tipostemporada.Find(e.temporada.tipotemporadaID);
                hstvs.Add(new HotelXTipoServicioXTemporadaView(e));
            }
            return hstvs;
        }

        public void agregarServicioXTemporada(int id, HotelXTipoServicioXTemporadaView pxtv)
        {
            database_table.agregarElemento(pxtv.deserializa(this));
        }

        public void eliminarServicioXTemporada(int id, int servicioXTemporada_id)
        {
            database_table.eliminarElemento(servicioXTemporada_id);
            return;
        }

        public void modificarTipoServicioXTemporada(int id, HotelXTipoServicioXTemporadaView pxtv)
        {
            HotelXTipoServicioXTemporada hst = pxtv.deserializa(this);
            database_table.modificarElemento(hst, hst.ID);
            return;            
        }

        public string retornaNombreHotel(int hotel_id)
        {
            Hotel hotel_perteneciente = database_table_hotel.retornarUnSoloElemento(hotel_id);
            return hotel_perteneciente.razon_social;
        }

        internal System.Web.Mvc.IView retornarHotelXServiciosXTemporada(int id)
        {
            throw new NotImplementedException();
        }
    }
}