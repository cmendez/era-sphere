using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaReservas.Controllers
{
    public class ReservaController : Controller
    {
        LogicaReserva reserva_logica = new LogicaReserva();

        public ActionResult Index()
        {
            ViewBag.reservas = reserva_logica.retornarReservas();
            return View("IndexReserva");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {
            ReservaView reserva_view= new ReservaView();
            if (TryUpdateModel(reserva_view))
            {
                Reserva reserva = reserva_view.deserializa(reserva_logica);
                reserva_logica.registrarReserva(reserva);

            }
            return View("IndexReserva"/*, new GridModel(cliente_logica.retonarClientesNaturales())*/);
        }

    }
}
