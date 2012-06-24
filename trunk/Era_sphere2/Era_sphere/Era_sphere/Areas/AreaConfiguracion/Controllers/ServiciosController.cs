using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaReservas;
using Era_sphere.Areas.AreaEventos.Models.Evento;


namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class ServiciosController : Controller
    {
        
        LogicaServicios servicios_logica = new LogicaServicios();
        LogicaReserva reserva_logica = new LogicaReserva();
        LogicaEvento reserva_evento = new LogicaEvento();
        //llamado par anhadir un servicio de reserva
        public ActionResult IndexServicioReserva(int id_reserva)
        {
            return View("ServiciosDeReservaIndex", new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica));
        }
        [GridAction]
        public ActionResult SelectReserva(int id_reserva)
        {
            return View("ServiciosIndex", new GridModel(new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica).servicios));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public JsonResult InsertServicioDeReserva(ServicioView servicio_view, int id_reserva)
        {
            Servicio s = servicio_view.deserializa(servicios_logica);
            servicios_logica.agregarServicio(s);
            servicios_logica.context.servicioxreservas.Add(new ServicioXReserva { reservaID = id_reserva, servicioID = s.ID });
            servicios_logica.context.SaveChanges();
            return Json(new { ok = true });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteReserva(int id, int id_reserva)
        {
            int servicio_id = id;
            reserva_logica.eliminaRelacionServicioXReserva(servicio_id, id_reserva);
            servicios_logica.eliminarServicio(servicio_id);
            return View("ServiciosIndex", new GridModel(new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica).servicios));
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Crear(int reservaID)
        {
            ViewData["edit"] = false;
            ViewData["reservaID"] = reservaID;
            return PartialView("CrearServicio");
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [GridAction]
        public ActionResult Mostrar(int servicio_id, int reservaID)
        {
            ViewData["edit"] = true;
            ViewData["reservaID"] = reservaID;
            return PartialView("CrearServicio", servicios_logica.retornarServicio(servicio_id)); 
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult Nada(int servicio_id)
        {
            return Json(new { servicio_id = servicio_id }, JsonRequestBehavior.AllowGet);
        }

        //Evento
        //public ActionResult IndexServicioEvento(int id_evento)
        //{
        //    return View("ServiciosDeReservaIndex", new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica));
        //}
    }
}
