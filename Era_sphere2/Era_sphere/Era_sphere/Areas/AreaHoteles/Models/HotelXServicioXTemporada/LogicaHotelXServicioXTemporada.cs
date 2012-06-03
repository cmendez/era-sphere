﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM
{
    public class LogicaHotelXServicioXTemporada
    {

        //logicahpt.retornarServiciosXTemporada()
        //logicahpt.eliminarServicioXTemporada(servicioXTemporada_id);
        //logicahpt.modificarCosteableXTemporada(p);
        //logicahpt.agregarServicioXTemporada(hpt_view);



        EraSphereContext hxsxt_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXServicioXTemporada> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaHotelXServicioXTemporada()
        {
            database_table = new DBGenericQueriesUtil<HotelXServicioXTemporada>(hxsxt_context, hxsxt_context.hxsxts);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxsxt_context, hxsxt_context.hoteles);
        }


        public List<HotelXServicioXTemporadaView> retornarServiciosXTemporada(int hid)
        {
            List<HotelXServicioXTemporada> hxsxts = database_table.retornarTodos();
            hxsxts = hxsxts.Where(e => e.hotelID == hid).ToList();
            List<HotelXServicioXTemporadaView> hstvs = new List<HotelXServicioXTemporadaView>();
            foreach (HotelXServicioXTemporada e in hxsxts)
            {
                e.servicio = hxsxt_context.servicios.Find(e.servicioID);
                e.temporada = hxsxt_context.temporadas.Find(e.temporadaID);
                e.temporada.tipotemporada = hxsxt_context.tipostemporada.Find(e.temporada.tipotemporadaID);
                hstvs.Add(new HotelXServicioXTemporadaView(e));
            }
            return hstvs;
        }

        public void agregarServicioXTemporada(int id, HotelXServicioXTemporadaView pxtv)
        {
            database_table.agregarElemento(pxtv.deserializa());
        }

        public void eliminarServicioXTemporada(int id, int servicioXTemporada_id)
        {
            database_table.eliminarElemento(servicioXTemporada_id);
            return;
        }

        public void modificarServicioXTemporada(int id, HotelXServicioXTemporadaView pxtv)
        {
            HotelXServicioXTemporada hst = pxtv.deserializa();
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