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
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using Era_sphere.Areas.AreaEventos.Models.Evento;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class PagosController: Controller
    {
        LogicaServicios logica = new LogicaServicios();
        LogicaMoneda moneda = new LogicaMoneda();

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
            ViewData["hotelID"] = r.hotelID;
            ViewData["Monedas"] = moneda.retornarMonedas();            
            ViewData["costo_total"] = r.costo_final;
            return PartialView("CorteDeCuenta", r.getReciboLineas());
        }

        public JsonResult PagarLineas(int[] lineas_ids, int clienteID, string tipo, decimal monto_tarjeta, decimal monto_contado, decimal monto_total, int reservaID)
        {
            var recibos_lineas = logica.context.recibos_lineas.Where(x => lineas_ids.Contains(x.ID)).ToList();
            decimal puntosratio = logica.context.cadenas.Find(1).ptos_x_dolar;
            Cliente c = logica.context.clientes.Find(clienteID);
            Recibo recibo = new Recibo();
            recibo.cliente = c;
            recibo.clienteID = c.ID;
            recibo.fecha = DateTime.Now;
            recibo.precio_contado = monto_contado;
            recibo.precio_tarjeta = monto_tarjeta;
            recibo.precio_total = monto_total;
            if (tipo == "Boleta") recibo.tipo = 0;
            else recibo.tipo = 1;
            logica.context.recibos.Add(recibo);

            foreach (var r in recibos_lineas)
            {
                r.pagado = true; 
                r.puntos = (int)(Math.Floor(r.precio_final * puntosratio));
                c.puntos_cliente = c.puntos_cliente + r.puntos;
                r.recibo = recibo;
                r.reciboID = recibo.ID;
            }
            recibo.reservaID = reservaID;
            logica.context.SaveChanges();
            return Json(new {ok = true, recibo_id = recibo.ID});
        }
        public JsonResult PagarLineasEvento(int clienteID/*, string tipo, decimal monto_tarjeta, decimal monto_contado, decimal monto_total*/, int eventoID)
        {

            Evento evento = logica.context.eventos.Find(eventoID);
            evento.estado_eventoID = 4;
            var recibos_lineas = evento.getReciboLineas();
            decimal puntosratio = logica.context.cadenas.Find(1).ptos_x_dolar;
            Cliente c = logica.context.clientes.Find(clienteID);
            Recibo recibo = new Recibo();
            recibo.cliente = c;
            recibo.clienteID = c.ID;
            recibo.fecha = DateTime.Now;
            DBGenericQueriesUtil<Recibo> database_table = new DBGenericQueriesUtil<Recibo>(logica.context, logica.context.recibos);
            foreach (var r in recibos_lineas)
            {
                r.pagado = true;
                r.puntos = (int)(Math.Floor(r.precio_final * puntosratio));
                c.puntos_cliente = c.puntos_cliente + r.puntos;
                r.recibo = recibo;
                r.reciboID = recibo.ID;
            }
            recibo.precio_total = evento.precio_total;
            recibo.eventoID = eventoID;
            recibo.recibo_lineas = new List<ReciboLinea>();
            int id = database_table.agregarElemento(recibo);
            recibo = database_table.retornarUnSoloElemento(id);
            foreach (var r in recibos_lineas)
            {
                recibo.recibo_lineas.Add(r);
                r.ID = recibo.ID;
            }
            logica.context.SaveChanges();

            return Json(new { ok = true, recibo_id = recibo.ID });
        }
    }
}