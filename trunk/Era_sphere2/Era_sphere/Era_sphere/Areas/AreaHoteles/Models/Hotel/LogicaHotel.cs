using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaHotel : InterfazLogicaHotel
    {

        EraSphereContext hotel_context = new EraSphereContext();
        DBGenericQueriesUtil<Hotel> database_table;

        public LogicaHotel() {
            database_table = new DBGenericQueriesUtil<Hotel>(hotel_context, hotel_context.hoteles);
        }

        public void agregarHotel(HotelView hotel)
        {
            database_table.agregarElemento( hotel.deserializa( this ) );  
        }

        public void modificarHotel(HotelView hotel_view)
        {
            Hotel hotel = hotel_view.deserializa( this );
            database_table.modificarElemento(hotel, hotel.ID);
            return;
        }

        public void eliminarHotel(int hotel_id)
        {
            database_table.eliminarElemento(hotel_id);
            return;
        }

        public List<HotelView> retornarHoteles()
        {
            List<Hotel> hoteles = database_table.retornarTodos();
            List<HotelView> hoteles_view = new List<HotelView>();

            foreach (Hotel hotel in hoteles) hoteles_view.Add(new HotelView(hotel));
            return hoteles_view;
        }

        public HotelView retornarHotel(int hotel_id)
        {
            Hotel hotel = database_table.retornarUnSoloElemento(hotel_id);
            HotelView hotel_view = new HotelView( hotel );
            return hotel_view;
        }


        public Ciudad retornarCiudad(int ciudad_id)
        {
            Ciudad ciudad = (new EraSphereContext()).ciudades.Find(ciudad_id);
            return ciudad;
        }

        public List<Pais> retornarPaises() {
            return (new EraSphereContext()).paises.ToList();
        }

        public List<Ciudad> retornarCiudades( int pais_id ) {
            List<Ciudad> res = (new EraSphereContext()).paises.Find(pais_id).ciudades.ToList();
            return res;
        }
    }
}