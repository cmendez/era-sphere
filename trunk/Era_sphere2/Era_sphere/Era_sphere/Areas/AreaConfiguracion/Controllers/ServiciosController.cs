using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaReservas;


namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class ServiciosController : Controller
    {
        
        LogicaServicios servicios_logica = new LogicaServicios();
        LogicaReserva reserva_logica = new LogicaReserva();
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
            reserva_logica.agregaRelacionServicioXReserva(id_reserva, s);
            return Json(new { ok = true });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteReserva(int id, int id_reserva)
        {
            var todos = servicios_logica.retornarServicios();
            int servicio_id = id;
            reserva_logica.eliminaRelacionServicioXReserva(servicio_id, id_reserva);
            servicios_logica.eliminarServicio(servicio_id);
            return View("ServiciosIndex", new GridModel(new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica).servicios));
        }
        
        public ActionResult Crear()
        {
            return PartialView("CrearServicio");
        }
        public JsonResult Nada(int servicio_id)
        {
            return Json(new { servicio_id = servicio_id });
        }
    }
}
