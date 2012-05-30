using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaContable.Models;
using Telerik.Web.Mvc;
using System.Web.Mvc;


namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /AreaContable/Proveedor/
        InterfazLogicaProveedor proveedor_logica = new LogicaProveedor();
        public ActionResult Index()
        {
            return View("IndexProveedor");
        }

        [GridAction]
        public ActionResult Select()
        {
            //ViewBag.proveedores = proveedor_logica.retornar();
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            ProveedorView proveedor_view = new ProveedorView();
            if (TryUpdateModel(proveedor_view))
            {
                proveedor_logica.agregarProveedor(proveedor_view);

            }
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int proveedor_id = id ?? -1;
            proveedor_logica.eliminarProveedor(proveedor_id);
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ProveedorView p)
        {

            proveedor_logica.modificarProveedor(p);
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
            // return RedirectToAction("proveedor");
        }
    }
}
