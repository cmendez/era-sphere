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

            //ReservaView reserva_view= new ReservaView();
            //if (TryUpdateModel(reserva_view))
            //{
            //    reserva_view.agregarCliente(reserva_view.deserializa(this.reserva_logica));
            //}
            return View("IndexReserva"/*, new GridModel(cliente_logica.retonarClientesNaturales())*/);
        }

    }
}
