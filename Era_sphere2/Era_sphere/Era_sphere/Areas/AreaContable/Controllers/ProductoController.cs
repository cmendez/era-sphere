using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Generics;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ProductoController : Controller
    {
        InterfazLogicaProducto producto_logica = new LogicaProducto();
        public ActionResult Index()
        {
            return View("IndexProducto");
        }

        [GridAction]
        public ActionResult Select()
        {
            return View("Index", new GridModel(producto_logica.retornarProductos()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            ProductoView producto_view = new ProductoView();
            if (TryUpdateModel(producto_view))
            {
                producto_logica.agregarProducto(producto_view);

            }
            return View("Index", new GridModel(producto_logica.retornarProductos()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int producto_id = id ?? -1;
            producto_logica.eliminarProducto(producto_id);
            return View("Index", new GridModel(producto_logica.retornarProductos()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ProductoView p)
        {
            producto_logica.modificarProducto(p);
            return View("Index", new GridModel(producto_logica.retornarProductos()));
        }
    }
}