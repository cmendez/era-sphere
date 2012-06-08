using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class LineaProductoController : Controller
    {

        InterfazLogicaLineaProducto lineaproducto_logica = new LogicaLineaProducto();
        public ActionResult Index()
        {
            return View("LineaProductoIndex", lineaproducto_logica.retornarLineasProducto());
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("LineaProductoIndex", new GridModel(lineaproducto_logica.retornarLineasProducto()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            LineaProductoView lineaproducto_view = new LineaProductoView();
            if (TryUpdateModel(lineaproducto_view))
            {
                lineaproducto_logica.agregarLineaProducto(lineaproducto_view);

            }
            return View("LineaProductoIndex", new GridModel(lineaproducto_logica.retornarLineasProducto()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int lineaproducto_id = id ?? -1;
            lineaproducto_logica.eliminarLineaProducto(lineaproducto_id);
            return View("LineaProductoIndex", new GridModel(lineaproducto_logica.retornarLineasProducto()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(LineaProductoView lpv)
        {

            lineaproducto_logica.modificarLineaProducto(lpv);
            return View("LineaProductoIndex", new GridModel(lineaproducto_logica.retornarLineasProducto()));
        }

    }
}
