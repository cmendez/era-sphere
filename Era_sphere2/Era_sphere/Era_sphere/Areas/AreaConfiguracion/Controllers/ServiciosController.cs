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
        public ActionResult Insert(int id_reserva)
        {

            ServicioView servicio_view = new ServicioView();
            if (TryUpdateModel(servicio_view))
            {
                servicios_logica.agregarServicio(servicio_view);

            }
            return View("ServiciosIndex", new GridModel(new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica).servicios));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id, int id_reserva)
        {
            int servicio_id = id ?? -1;
            servicios_logica.eliminarServicio(servicio_id);
            return View("ServiciosIndex", new GridModel(new ReservaView(reserva_logica.retornarReserva(id_reserva), reserva_logica).servicios));
        }

        
    }
}
