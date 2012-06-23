using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaContable.Models.Pagos;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class PagosController: Controller
    {
        LogicaServicios logica = new LogicaServicios();
        //llamado par anhadir un servicio de reserva
        public ActionResult PagoTarjetaDeCredito(decimal monto)
        {
            return PartialView("TarjetaDeCreditoIndex", new PagoTarjeta { monto = monto });
        }

        public ActionResult Validar(PagoTarjeta pt)
        {
            return View("TarjetaDeCreditoIndex", pt);
        }
        public ActionResult CorteDeCuenta(int reservaID)
        {
            ViewData["idCosteable"] = reservaID;
            Reserva r = logica.context.Reservas.Find(reservaID);
            return PartialView("CorteDeCuenta", r.getReciboLineas());
        }

        public JsonResult PagarLineas(int[] lineas_ids)
        {
            var recibos_lineas = logica.context.recibos_lineas.Where(x => lineas_ids.Contains(x.ID)).ToList();
            foreach (var r in recibos_lineas)
            {
                r.pagado = true;
            }
            logica.context.SaveChanges();
            return Json(new {ok = true});
        }
    }
}