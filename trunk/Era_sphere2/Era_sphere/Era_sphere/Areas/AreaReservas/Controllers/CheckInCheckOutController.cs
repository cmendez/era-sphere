using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaReservas.Controllers
{
    public class CheckInCheckOutController : Controller
    {
        //
        // GET: /AreaReservas/CheckInCheckOut/
        LogicaReserva reserva_logica = new LogicaReserva();

        public ActionResult Index(int id)
        {
            ViewBag.reservas = reserva_logica.retornarReservas();
            ViewData["hotelID"] = id;
            return View("IndexCheckInCheckOut");
        }


        [GridAction]
        public ActionResult Select(int id)
        {
            return View("IndexCheckInCheckOut", new GridModel(reserva_logica.retornarReservasHotel(id)));

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Nada(int reserva_id)
        {
            return Json(new { reserva_id = reserva_id });
        }

        //newbie
        public ActionResult CheckIn(int reserva_id)
        {
            LogicaReserva reserva_logica = new LogicaReserva();
            ReservaView reserva_view = new ReservaView(reserva_logica.retornarReserva(reserva_id), reserva_logica);
            
            return PartialView("CheckInViewTemplate", reserva_view);
        }


        public ActionResult CheckOut(int reserva_id)
        {
            LogicaReserva reserva_logica = new LogicaReserva();
            ReservaView reserva_view = new ReservaView(reserva_logica.retornarReserva(reserva_id), reserva_logica);

            return PartialView("CheckOutViewTemplate", reserva_view);
        }


        public JsonResult RealizarCheckIn(int reserva_id)
        {
            Reserva reserva = reserva_logica.retornarReserva(reserva_id);
            reserva_logica.cambiarEstadoReservaCheckIn(reserva);

            return Json(new { OK = true });
        }


        public JsonResult RealizarCheckOut(int reserva_id)
        {
            Reserva reserva = reserva_logica.retornarReserva(reserva_id);
            reserva_logica.cambiarEstadoCheckOut(reserva);

            return Json(new { OK = true });
        }


    }
}
