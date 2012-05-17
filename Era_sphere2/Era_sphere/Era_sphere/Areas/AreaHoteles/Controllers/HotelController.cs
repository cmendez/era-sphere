using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /AreaHoteles/Hotel/
        InterfazLogicaHotel hotel_logica = new LogicaHotel();
        public ActionResult Index()
        {
            return View("IndexHotel");
        }

        [GridAction]
        public ActionResult Select()
        {
            ViewBag.proveedores = hotel_logica.retornarProveedores();
            return View("Index", new GridModel(proveedor_logica.retornarProveedores()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            HotelView proveedor = new HotelView();
            if (TryUpdateModel(proveedor))
            {
                proveedor_logica.agregarProveedor(proveedor);

            }
            return View("Index", new GridModel(hotel_logica.retor()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int _proveedor_id = id ?? -1;
            hotel_logica.eliminarHotel(_proveedor_id);
            return View("Index", new GridModel(hotel_logica.retornarClientes()));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(Hotel p)
        {

            hotel_logica.modificarHotel(p);
            return View("Index", new GridModel(hotel_logica.retornarClientes()));
            // return RedirectToAction("proveedor");
        }
    }
}
