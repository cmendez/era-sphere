using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using System.Data;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class MonedaController : Controller
    {
        InterfazLogicaMoneda moneda_logica = new LogicaMoneda();
        public ActionResult Index()
        {
            return View("IndexMoneda");
        }

        [GridAction]
        public ActionResult Select()
        {
            return View("Index", new GridModel(moneda_logica.retornarMonedas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            MonedaView moneda_view = new MonedaView();
            if (TryUpdateModel(moneda_view))
            {
                moneda_logica.agregarMoneda(moneda_view);

            }
            return View("Index", new GridModel(moneda_logica.retornarMonedas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int moneda_id = id ?? -1;
            moneda_logica.eliminarMoneda(moneda_id);
            return View("Index", new GridModel(moneda_logica.retornarMonedas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(MonedaView p)
        {
            moneda_logica.modificarMoneda(p);
            return View("Index", new GridModel(moneda_logica.retornarMonedas()));
        }
    }
}
