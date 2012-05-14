using System.Web.Mvc;
using Era_sphere.Areas.AreaProveedores.Models;
using Telerik.Web.Mvc;
namespace Era_sphere.Areas.AreaProveedores.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /AreaProveedores/Proveedor/

        InterfazLogicaProveedor proveedor_logica = new LogicaProveedor();

        public ActionResult Filtrado( string razon_social , string ruc ) {
            return View("Index", proveedor_logica.retornarProveedores());
        }

        public ActionResult proveedores()
        {
            ViewBag.proveedores = proveedor_logica.retornarProveedores();
            return View("Index", proveedor_logica.retornarProveedores());
        }

        [GridAction]
        public ActionResult Select()
        {
            ViewBag.proveedores = proveedor_logica.retornarProveedores();
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert() {
       
            Proveedor proveedor = new Proveedor();
            if (TryUpdateModel(proveedor)) {
                proveedor_logica.agregarProveedor(proveedor);
                
            }
            return View("Index",new GridModel( proveedor_logica.retornarProveedores() ));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete( int? id)
        {
            int _proveedor_id = id ?? -1;
            proveedor_logica.eliminarProveedor(_proveedor_id);
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update( Proveedor p ) {

            proveedor_logica.modificarProveedor(p);
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
           // return RedirectToAction("proveedor");
        }
    }
}
