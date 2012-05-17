using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class PisoController : Controller
    {
        //
        // GET: /AreaHoteles/Piso/
        InterfazLogicaPiso piso_logica = new LogicaPiso();
        public ActionResult Index(int hotel_id)
        {
            ViewBag.hotel_id = hotel_id;
            return View("IndexPiso");
        }

        [GridAction]
        public ActionResult Select(int hotel_id)
        {
            
            return View("IndexPiso", new GridModel( piso_logica.retornarPisos(hotel_id) ) );
        }
        public ActionResult Delete(int? id)
        {
            int piso_id = id ?? -1;
            piso_logica.eliminarPiso(piso_id);
            return View("Index", new GridModel(piso_logica.retornarPisos(hotel_id)));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(PisoView p)
        {

            piso_logica.modificarPiso(p);
            return View("Index", new GridModel(piso_logica.retornarPisos(hotel_id)));
            // return RedirectToAction("proveedor");
        }

        public int hotel_id { get; set; }
    }
}
