using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaReservas.Controllers
{
    public class ReservaController : Controller
    {
        LogicaReserva reserva_logica = new LogicaReserva();

        public ActionResult Index(int id)
        {
            ViewBag.reservas = reserva_logica.retornarReservas();
            ViewData["hotelID"] = id;
            return View("IndexReserva");
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservasHotel(id)));

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int id)
        {
            ReservaView reserva_view= new ReservaView();
            if (TryUpdateModel(reserva_view))
            {
                reserva_view.estadoID = 1;
                reserva_view.hotelID = id;
                Reserva reserva = reserva_view.deserializa(reserva_logica);
                reserva_logica.registrarReserva(reserva);
                
            }
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservasHotel(id)));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int reserva_id = id ?? -1;
            reserva_logica.eliminarReserva(reserva_id);
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservasHotel(id_hotel)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ReservaView reserva, int id_hotel)
        {
            reserva_logica.modificarReserva(reserva.deserializa(reserva_logica));
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservasHotel(id_hotel)));
        }

        
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RefrescaHabitaciones(List<int> hab_ids, int reserva_id)
        {
            hab_ids = hab_ids ?? new List<int>();
            reserva_logica.refrescaHabitaciones(hab_ids, reserva_id);
            reserva_logica.cacularDatosReserva(reserva_id);

            return Json(new {data = true});
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AnulaReserva(int reserva_id)
        {
            reserva_logica.cambiarEstadoReservaAnular(reserva_logica.retornarReserva(reserva_id));
            return Json(new {reserva_id = reserva_id});

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Nada(int reserva_id)
        {
            return Json(new { reserva_id = reserva_id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ObtieneDatosHabitacion(int habitacion_id)
        {
            Habitacion h = reserva_logica.context.habitaciones.Find(habitacion_id);
            return Json(new { num_camas = h.tipoHabitacion.numero_camas, capacidad = h.tipoHabitacion.cap_max_personas });
        }

        public ActionResult habitacionesCliente(int reserva_id)
        {
            List<HabitacionXReservaXClienteLineaView> lineas = new List<HabitacionXReservaXClienteLineaView>();
            return PartialView("ReservaHabitacionClienteView", new HabitacionXReservaXClienteView(reserva_id,lineas));
        }

        [GridAction]
        public ActionResult SelectClienteHabitacion(int id_reserva)
        {
            return PartialView("ReservaHabitacionClienteView", new GridModel(reserva_logica.retornarHabitacionReservaCliente(id_reserva)));

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult InsertClienteHabitacion(int id_cliente, int id_reserva, int id_habitacion)
        {
            reserva_logica.agregarLinea(id_reserva, id_habitacion, id_cliente);
            return Json(new {ok = true});

        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteClienteHabitacion(int id_cliente, int id_reserva, int id_habitacion)
        {
            reserva_logica.eliminarLinea(id_reserva, id_habitacion, id_cliente);
            return PartialView("ReservaHabitacionClienteView", new GridModel(reserva_logica.retornarHabitacionReservaCliente(id_reserva)));
        }

    }
}
