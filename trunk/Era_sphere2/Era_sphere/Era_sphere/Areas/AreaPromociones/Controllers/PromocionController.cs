using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaPromociones.Models;

namespace Era_sphere.Areas.AreaPromociones.Controllers
{
    public class PromocionController : Controller
    {
        //
        // GET: /AreaPromociones/Promocion/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        InterfazLogicaPromocion promocion_logica = new LogicaPromocion();
        
        [HttpPost]
        public JsonResult getPromociones (int puntos) {
            var promociones = promocion_logica.retornarpromociones(puntos);
            return new JsonResult() { Data = promociones };
        }
        
        public ActionResult Index()
        {
            return View("PromocionIndex", promocion_logica.retornarPromociones());
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("PromocionIndex", new GridModel(promocion_logica.retornarPromociones()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            PromocionView promocion_view = new PromocionView();
            if (TryUpdateModel(promocion_view))
            {
                promocion_logica.agregarPromocion(promocion_view);

            }
            return View("PromocionIndex", new GridModel(promocion_logica.retornarPromociones()));
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int promocion_id = id ?? -1;
            promocion_logica.eliminarPromocion(promocion_id);
            return View("PromocionIndex", new GridModel(promocion_logica.retornarPromociones()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(PromocionView p)
        {

            promocion_logica.modificarPromocion(p);
            return View("PromocionIndex", new GridModel(promocion_logica.retornarPromociones()));
        }


    }
}
