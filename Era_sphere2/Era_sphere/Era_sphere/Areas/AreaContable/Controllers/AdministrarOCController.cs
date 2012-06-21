using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class AdministrarOCController : Controller
    {
        //
        // GET: /AreaContable/AdministrarOC/
        LogicaOrdenCompra logica = new LogicaOrdenCompra();

        #region Administrar Orden

        [GridAction]
        ActionResult default_admin(int id_hotel)
        {
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra(id_hotel)));
        }
        public ActionResult IndexAdministracion(int id)
        {
            ViewBag.id_hotel = id;
            return View();
        }
        [GridAction]
        public ActionResult SelectOrdenes(int id_hotel , int estado_orden)
        {
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra_estado(id_hotel , estado_orden )));
        }

        [GridAction]
        public ActionResult EliminarOrdenCompra(int id , int estado_orden) {
            int id_hotel = logica.retornar_orden(id).hotelID;
            logica.elimina_orden_compra(id);
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra_estado( id_hotel, estado_orden )));
        }
        [GridAction]
        public ActionResult DetallesOrdenC( int id ) {
            return Json(new { msg = "ok" , orden_compra = logica.retornar_orden( id ) });
        }

        public ActionResult aceptarOrdenCompra(int id_oc) {
            string msg = "La orden " + id_oc+ " fue aceptada";
            try { logica.aceptar_orden_compra(id_oc); }
            catch (Exception e) { msg = e.Message; }

            return Json(new { msg = msg });
        }

        public ActionResult terminarOrdenCompra(int id_oc ) {
            string msg = "La orden "+ id_oc + " fue teminada de atender";
            try { logica.terminar_orden_compra(id_oc); }
            catch (Exception ex) { msg = ex.Message; }
            return Json(new { msg = msg });
        }

        public ActionResult cancelarOrdenCompra(int id_oc) {
            string msg = "La orden " + id_oc + " fue cancelada";
            try { logica.cancelar_orden_compra(id_oc); }
            catch (Exception ex) { msg = ex.Message;  }
            return Json(new { msg = msg });
        }
        public JsonResult OrdenDeCompra (int id_oc)
        {
            OrdenCompraView p = logica.retornar_orden(id_oc);
            return Json(new { oc = p });
        }
        #endregion

    }
}
