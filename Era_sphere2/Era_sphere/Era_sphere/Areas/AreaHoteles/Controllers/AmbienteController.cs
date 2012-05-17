using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class AmbienteController : Controller
    {
        //
        // GET: /AreaHoteles/Ambiente/

        InterfazLogicaAmbiente logica_ambiente = new LogicaAmbiente();
        InterfazLogicaPiso logica_pisos = new LogicaPiso();

        public ActionResult Index()
        {
            ViewData["pisos"] = logica_pisos.retornarPisos();
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

        [GridAction]
        public ActionResult _pisos()
        {
            return View(new GridModel(logica_ambiente.retornarAmbientes()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _pisosUpdate(int id, int piso_id)
        {
            var ambiente = new Ambiente{
                ID = id,
                piso = logica_pisos.retornarPiso(piso_id).deserializa(logica_pisos)
            };
            // Exclude "Employee" from the list of updated properties
            if (TryUpdateModel(ambiente, null, null, new[] { "Ambiente" }))
            {
                logica_ambiente.modificarAmbiente(new AmbienteView(ambiente));
            }
            return View(new GridModel(logica_ambiente.retornarAmbientes()));
        }
    }
}
