using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class PoliticasController : Controller
    {
        //
        // GET: /AreaConfiguracion/Politicas/
        InterfazLogicaCadena cadena_logica = new LogicaCadena();
        public ActionResult Index()
        {
            return View("IndexPoliticas");
        }

        [GridAction]
        public ActionResult Select()
        {
            CadenaView cv = new CadenaView(cadena_logica.retornarCadena(0));
            return View("Index", new GridModel(cv));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(CadenaView p)
        {
            ubigeo_logica.modificarPais(p);
            return View("Index", new GridModel(ubigeo_logica.retornarPaises()));
        }


    }
}
