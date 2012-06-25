using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM
{
    public class LogicaHotelXTipoHabitacionXTemporada
    {

        //logicahpt.retornarTipoHabitacionsXTemporada()
        //logicahpt.eliminarTipoHabitacionXTemporada(tipoHabitacionXTemporada_id);
        //logicahpt.modificarCosteableXTemporada(p);
        //logicahpt.agregarTipoHabitacionXTemporada(hpt_view);



        EraSphereContext hxthxt_context = new EraSphereContext();
        DBGenericQueriesUtil<HotelXTipoHabitacionXTemporada> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaHotelXTipoHabitacionXTemporada()
        {
            database_table = new DBGenericQueriesUtil<HotelXTipoHabitacionXTemporada>(hxthxt_context, hxthxt_context.hxthxts);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(hxthxt_context, hxthxt_context.hoteles);
        }


        public List<HotelXTipoHabitacionXTemporadaView> retornarTipoHabitacionsXTemporada(int hid)
        {
            List<HotelXTipoHabitacionXTemporada> hxthxts = database_table.retornarTodos();
            hxthxts = hxthxts.Where(e => e.hotelID == hid).ToList();
            List<HotelXTipoHabitacionXTemporadaView> hthtvs = new List<HotelXTipoHabitacionXTemporadaView>();
            foreach (HotelXTipoHabitacionXTemporada e in hxthxts)
            {
                e.tipoHabitacion = hxthxt_context.tipos_habitacion.Find(e.tipoHabitacionID);
                e.temporada = hxthxt_context.temporadas.Find(e.temporadaID);
                e.temporada.tipotemporada = hxthxt_context.tipostemporada.Find(e.temporada.tipotemporadaID);
                hthtvs.Add(new HotelXTipoHabitacionXTemporadaView(e));
            }
            return hthtvs;
        }

        public List<HotelXTipoHabitacionXTemporada> retornarTipoHabitacionsXTemporada2(int hid)
        {
            List<HotelXTipoHabitacionXTemporada> hxthxts = database_table.retornarTodos();
            hxthxts = hxthxts.Where(e => e.hotelID == hid).ToList();
            return hxthxts;
        }

        public void agregarTipoHabitacionXTemporada(int id, HotelXTipoHabitacionXTemporadaView hxthxt)
        {
            database_table.agregarElemento(hxthxt.deserializa());
        }

        public void eliminarTipoHabitacionXTemporada(int idHotelXTHXT)
        {
            database_table.eliminarElemento_logico(idHotelXTHXT);
            return;
        }

        public void modificarTipoHabitacionXTemporada(int id, HotelXTipoHabitacionXTemporadaView hxthxt)
        {
            HotelXTipoHabitacionXTemporada hpt = hxthxt.deserializa();
            database_table.modificarElemento(hpt, hpt.ID);
            return;            
        }

        public decimal getPrecioTipoHabitacion(int hotelID, int tipo_habitacionID, DateTime fecha)
        {
            if (tipo_habitacionID == -1) return 0;
            LogicaTemporada lt = new LogicaTemporada();
            Temporada temporada = lt.retornarTemporada(fecha);
            var res = this.hxthxt_context.hxthxts.FirstOrDefault(x => x.hotelID == hotelID && x.temporadaID == temporada.ID && x.tipoHabitacionID == tipo_habitacionID);
            return res == null ? this.hxthxt_context.tipos_habitacion.Find(tipo_habitacionID).costo_base : res.precio;
        }

        public IEnumerable<TipoHabitacion> retornarTiposHabitaciones(int hotel_id)
        {

            List<HotelXTipoHabitacionXTemporada> hxthxts = this.retornarTipoHabitacionsXTemporada2(hotel_id);
            List<TipoHabitacion> thabs = new List<TipoHabitacion>();
            foreach (HotelXTipoHabitacionXTemporada hxthxt in hxthxts)
            {
                thabs.Add(hxthxt.tipoHabitacion);
            }
            return thabs.Distinct();
            //return (List<TipoHabitacion>)thabs.Distinct();
        }

        public int contarDuplicados(int hotelID, int tipoHabitacionID, int temporadaID)
        {
            List<HotelXTipoHabitacionXTemporada> hxthxts = this.retornarTipoHabitacionsXTemporada2(hotelID);
            return hxthxts.Count(e => e.tipoHabitacionID == tipoHabitacionID && e.temporadaID == temporadaID);
        }

        public decimal retornarCostoBase(int? tipohabitacionID)
        {
            return (new LogicaTipoHabitacion()).retornarCostoBase(tipohabitacionID);
        }
    }
}