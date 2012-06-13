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
        public ActionResult SelectRegistradas(int id_hotel)
        {
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra_registradas(id_hotel)));
        }

        [GridAction]
        public ActionResult EliminarOrdenCompra(int id) {
            logica.elimina_orden_compra(id);
            return Json(new { msg = id });
        }
        [GridAction]
        public ActionResult DetallesOrdenC( int id ) {
            return Json(new { msg = "ok" , orden_compra = logica.retornar_orden( id ) });
        }
        #endregion

    }
}
