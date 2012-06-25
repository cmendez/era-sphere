using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaHabitacion
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Habitacion> database_table;
        
        public LogicaHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< Habitacion >(context, context.habitaciones);
        }

        public List<Habitacion> retornarHabitacionesDeHotel(int id_hotel)
        {
            var habitaciones = database_table.retornarTodos().Where(e => e.piso.hotel.ID == id_hotel);
            return habitaciones.ToList();
        }

        public List<HabitacionView> retornarHabitacionesViewDeHotel( int id_hotel )
        {
            var habitaciones = this.retornarHabitacionesDeHotel(id_hotel);
            var habitacion_view = new List<HabitacionView>();
            foreach (Habitacion habitacion in habitaciones) habitacion_view.Add(new HabitacionView(habitacion));
            return habitacion_view;
        }

        public HabitacionView retornarHabitacion(int habitacion_id)
        {
            Habitacion habitacion = database_table.retornarUnSoloElemento(habitacion_id);
            HabitacionView habitacion_view = new HabitacionView(habitacion);
            return habitacion_view;
        }

        public void modificarHabitacion(HabitacionView habitacion_view)
        {
            Habitacion modif = habitacion_view.deserializa(this);  
            database_table.modificarElemento(modif, modif.ID);
            return;
        }

        public void agregarHabitacion(HabitacionView habitacion)
        {
            Habitacion habitacion_per = habitacion.deserializa(this);
            //habitacion_per.tipoHabitacion = habitacion_context.tipos_habitacion.Find(habitacion_per.tipoHabitacionID);
            database_table.agregarElemento(habitacion_per);
        }

        public void eliminarHabitacion(int habitacion_id)
        {
            database_table.eliminarElemento_logico(habitacion_id);
        }

        /*public List<Habitacion> buscarHabitacion(Habitacion habitacion_campos)
        {
            return database_table.buscarElementos(habitacion_campos);
        }*/

        public List<Habitacion> retornarHabitacionesLibres(int hotelID, int pisoID, int tipohabitacionID, DateTime desde, DateTime hasta)
        {
            List<Habitacion> habs_de_hotel = this.retornarHabitacionesDeHotel(hotelID);
            if (pisoID != 0) habs_de_hotel = habs_de_hotel.Where(p => p.pisoID == pisoID).ToList();
            if (tipohabitacionID != 0) habs_de_hotel = habs_de_hotel.Where(p => p.tipoHabitacionID == tipohabitacionID).ToList();
            List<Reserva> reservas2 = context.Reservas.ToList();
            List<Reserva> reservas = context.Reservas.Where(r => r.estado.descripcion != "Anulada" && r.estado.descripcion != "CheckedOut" &&
                                                            (desde >= r.check_in && desde < r.check_out ||
                                                              r.check_in >= desde && r.check_in < hasta)).ToList();
            HashSet<int> habitaciones_malas = new HashSet<int>();
            foreach(var r in reservas){
                 var aux = context.habitacion_x_reserva.Where(x => x.reservaID == r.ID).Select(x => x.habitacionID).ToList();
                habitaciones_malas.UnionWith(aux);
            }
            return habs_de_hotel.Where(r => !habitaciones_malas.Contains(r.ID)).ToList();
            //TODO falta hacer la consulta de verdad
                         
        }

        public List<Piso> retornarPisos(int hotel_id)
        {
            return (new LogicaPiso()).retornarPisos2(hotel_id);
        }

        public IEnumerable<TipoHabitacion> retornarTiposHabitacion(int hotel_id)
        {
            //return (new LogicaHotelXTipoHabitacionXTemporada()).retornarTiposHabitaciones(hotel_id);
            return null;
        }

        public List<Habitacion> retornarHabitacionesDePiso(int pisoID)
        {
            List<Habitacion> hbs = database_table.retornarTodos();
            hbs = hbs.Where(hb => hb.pisoID == pisoID).ToList();
            return hbs;
        }
    }
}