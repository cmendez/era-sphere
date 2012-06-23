using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaContable.Models.Pagos;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaClientes.Models;

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
            ViewData["clienteID"] = r.responsable_pagoID;
            return PartialView("CorteDeCuenta", r.getReciboLineas());
        }

        public JsonResult PagarLineas(int[] lineas_ids, int clienteID)
        {
            var recibos_lineas = logica.context.recibos_lineas.Where(x => lineas_ids.Contains(x.ID)).ToList();
            decimal puntosratio = logica.context.cadenas.Find(1).ptos_x_dolar;
            Cliente c = logica.context.clientes.Find(clienteID);
            foreach (var r in recibos_lineas)
            {
                r.pagado = true; 
                r.puntos = (int)(Math.Floor(r.precio_final * puntosratio));
                c.puntos_cliente = c.puntos_cliente + r.puntos;
            }
            logica.context.SaveChanges();
            return Json(new {ok = true});
        }
    }
}