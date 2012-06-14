using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using System.Threading;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /AreaContable/Proveedor/
        LogicaProveedor proveedor_logica = new LogicaProveedor();
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

        #region Productos
        public ActionResult Productos( int id_proveedor ){
            ViewData["Proveedor"] = proveedor_logica.context_publico.proveedores.Find( id_proveedor );

            return View("ProductosProveedor",  proveedor_logica.productos_de_proveedor(id_proveedor) ) ;
        }

        [GridAction]
        public ActionResult SelectProductos(int id_proveedor) {
            int id = id_proveedor;
            ViewData["ProveedorID"] = id;
            ViewData["Proveedor"] = proveedor_logica.context_publico.proveedores.Find(id);
            return View("ProductosProveedor", new GridModel( proveedor_logica.productos_de_proveedor(id)) );
        }

        [GridAction]
        public ActionResult InsertProductos( int id_proveedor , proveedor_x_productoView producto ){
            int id = id_proveedor;
            ViewData["ProveedorID"] = id;
            ViewData["Proveedor"] = proveedor_logica.context_publico.proveedores.Find(id);
            proveedor_logica.agregarProductoAProveedor(id, producto);
            return Json( new{ msg = "ok" } );
        }
        [GridAction]
        public ActionResult UpdateProductos(int id_proveedor, proveedor_x_productoView producto) {
            int id = id_proveedor;
            ViewData["ProveedorID"] = id;
            ViewData["Proveedor"] = proveedor_logica.context_publico.proveedores.Find(id);
            proveedor_logica.modificar_producto(id_proveedor, producto);
            return View("ProductosProveedor", new GridModel( proveedor_logica.productos_de_proveedor(id) ));
        }
        [GridAction]
        public ActionResult DeleteProductos(int id_proveedor, proveedor_x_productoView producto) {
            int id = id_proveedor;
            ViewData["ProveedorID"] = id;
            ViewData["Proveedor"] = proveedor_logica.context_publico.proveedores.Find(id);

            proveedor_logica.eliminar_producto(id_proveedor, producto);
            return View("ProductosProveedor", new GridModel( proveedor_logica.productos_de_proveedor(id)));
        }

        public ActionResult ProductosRestantes(string producto, int id_proveedor) {
            int id = id_proveedor;
            Thread.Sleep(500);
            return Json( new SelectList( proveedor_logica.productosRestantes( producto , id ), "ID" , "descripcion"));
        }
        public ActionResult DetallesProductoProveedor(int id_product) {
            return PartialView(proveedor_logica.producto_proveedor(id_product));
        }
        #endregion
        #region Hotel
        public ActionResult Hoteles(int id_proveedor) {
            inicializa_proveedor(id_proveedor);
            return View("HotelesProveedor", proveedor_logica.hoteles_de_proveedor( id_proveedor )); 
        }

        public ActionResult InsertHoteles(int id_proveedor, int id_hotel) {
            inicializa_proveedor(id_proveedor);
            bool hay_error = false;
            string msg = "feliz";
            try
            {
                proveedor_logica.agregar_hotel_proveedor(id_proveedor, id_hotel);
            }
            catch (Exception e) { 
                hay_error = true;
                msg = e.ToString();
            }
            return Json(new { error = hay_error , msg = msg } );
        }

        [GridAction]
        public ActionResult DeleteHoteles(int id_proveedor, HotelView hotel) {
            ModelState.Clear();
            inicializa_proveedor(id_proveedor);
            proveedor_logica.elimina_hotel(id_proveedor, hotel);
            return View("HotelesProveedor", new GridModel(proveedor_logica.hoteles_de_proveedor(id_proveedor)));
        }
        [GridAction]
        public ActionResult SelectHoteles(int id_proveedor) {
            inicializa_proveedor(id_proveedor);
            return default_action_hotel(id_proveedor);
        }

        public ActionResult HotelesRestantes(string hotel , int id_proveedor) {
            inicializa_proveedor(id_proveedor);
            Thread.Sleep(500);
            return Json(new SelectList(proveedor_logica.hoteles_restantes(hotel, id_proveedor), "ID", "razon_social"));
        }

        public ActionResult SelectPartialHotel(int id_proveedor) {
            ViewData["id"] = id_proveedor;
            return PartialView("HotelProveedorPartial");
        }

        #endregion
        #region Utils
        void inicializa_proveedor( int id ) {
            ViewBag.proveedor = proveedor_logica.retornarProveedor(id);
        }
        ViewResult default_action_hotel( int id_proveedor ) {
            return View("HotelesProveedor", new GridModel( proveedor_logica.hoteles_de_proveedor( id_proveedor ) ));
        }

        public JsonResult Proveedor(int id_proveedor)
        {
            ProveedorView p = proveedor_logica.retornarProveedor(id_proveedor);
            return Json(new { proveedor = p });
        }
        #endregion
    }
}
