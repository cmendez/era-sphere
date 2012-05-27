using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class FiscalController : Controller
    {
 
        //
        // GET: /AreaConfiguracion/Fiscal/
        InterfazLogicaUbigeo ubigeo_logica = new LogicaUbigeo();
        public ActionResult Index()
        {
            return View("IndexFiscal");
        }

        [GridAction]
        public ActionResult Select()
        {
            return View("Index", new GridModel( ubigeo_logica.retornarPaises() ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(PaisView p)
        {
            ubigeo_logica.modificarPais(p);
            return View("Index", new GridModel(ubigeo_logica.retornarPaises()));
        }

    }
}
