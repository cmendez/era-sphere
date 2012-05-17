using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Era_sphere.Areas.Configuracion.Models;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public  interface InterfazLogicaHotel
    {
        void agregarHotel(HotelView hotel);
        void modificarHotel(HotelView hotel);
        void eliminarHotel(int hotel_id);
        List<HotelView> retornarHoteles();
        HotelView retornarHotel(int hotel_id);
        Ciudad retornarCiudad(int ciudad_id);
        List<Ciudad> retornarCiudades(int pais_id);
    }
}
