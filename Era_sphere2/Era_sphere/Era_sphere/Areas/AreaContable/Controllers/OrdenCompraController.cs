using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Telerik.Web.Mvc;
using System.Threading;
using Era_sphere.Areas.AreaContable.Models.Ordenes;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class OrdenCompraController : Controller
    {

        LogicaOrdenCompra logica = new LogicaOrdenCompra();

        //
        // GET: /AreaContable/OrdenesCompra/

        public ActionResult Index()
        {
            return View();
        }

        [GridAction]
        public ActionResult Select() {
            return View(new GridModel(logica.retornar_ordenes()));
        }
        #region OrdenCompra
        public ActionResult crearOrdenView( int id_proveedor ) {
            ViewBag.proveedor = (new LogicaProveedor()).retornarProveedor(id_proveedor);
            ViewBag.orden_compra = logica.retornar_orden_nueva( id_proveedor );
            return PartialView("ordenCompraPartial");
        }
        public ActionResult ProductosProveedor(int id_proveedor) {
            Thread.Sleep(500);
            LogicaProveedor prov = new LogicaProveedor();
            return Json(new SelectList( prov.productos_de_proveedor( id_proveedor ),"ID" ,"descripcion_producto" ));
        }
        public ActionResult InsertOCLinea(int id_oc, int id_producto, int cantidad) {
            try
            {
                logica.insertar_linea(id_oc, id_producto, cantidad);
                return Json(new { msg = "ok" });
            }
            catch (Exception e) {
                return Json(new { msg = "error" });
            }
        }
        [GridAction]
        public ActionResult SelectOCompraLinea( int id_oc ){
            return View(new GridModel( logica.retornar_lineas( id_oc ) ));
        }
        [GridAction]
        public ActionResult DeleteOCL(int id_oc, int id) {
            logica.eliminar_linea(id_oc, id);
            return View(new GridModel( logica.retornar_lineas( id_oc ) ));
        }
        public ActionResult DeleteOrdenCompra(int id_oc) {
            logica.elimina_orden_compra(id_oc);
            return Json(new { msg = "ok" });
        }
        #endregion
    }
}
