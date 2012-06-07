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

        [GridAction]
        public ActionResult Select()
        {
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservas()));

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
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservas()));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int reserva_id = id ?? -1;
            reserva_logica.eliminarReserva(reserva_id);
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservas()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ReservaView reserva)
        {
            reserva_logica.modificarReserva(reserva.deserializa(reserva_logica));
            return View("IndexReserva", new GridModel(reserva_logica.retornarReservas()));
        }


        //falta metodos para llamar al modal
    }
}
