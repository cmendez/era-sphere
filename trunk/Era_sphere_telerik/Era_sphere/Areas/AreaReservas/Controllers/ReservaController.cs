using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;

namespace Era_sphere.Areas.AreaReservas.Controllers
{
    public class ReservaController : Controller
    {
        LogicaReserva reserva_logica = new LogicaReserva();

        public ActionResult Index()
        {
            ViewBag.reservas = reserva_logica.retornarReservas();
            return View();
        }

    }
}
