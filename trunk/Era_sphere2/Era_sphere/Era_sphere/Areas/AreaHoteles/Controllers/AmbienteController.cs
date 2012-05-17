using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class AmbienteController : Controller
    {
        //
        // GET: /AreaHoteles/Ambiente/

        InterfazLogicaAmbiente logica_ambiente = new LogicaAmbiente();

        public ActionResult Index()
        {
            return View("IndexAmbiente");
        }

        [GridAction]
        public ActionResult select()
        {
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes()));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert()
        {
            AmbienteView ambiente_view = new AmbienteView();
            if (TryUpdateModel(ambiente_view))
            {
                logica_ambiente.agregarAmbiente(ambiente_view);
            }
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id)
        {
            int ambiente_id = id ?? -1;
            logica_ambiente.eliminarAmbiente(ambiente_id);
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes()));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(AmbienteView ambiente)
        {

            logica_ambiente.modificarAmbiente(ambiente);
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes()));
            // return RedirectToAction("proveedor");
        }

    }
}
