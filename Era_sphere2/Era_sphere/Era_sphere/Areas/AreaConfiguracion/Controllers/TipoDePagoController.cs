using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using System.Data;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TipoDePagoController : Controller
    {
        InterfazLogicaTipoDePago tipodepago_logica = new LogicaTipoDePago();
        public ActionResult Index()
        {
            return View("IndexTipoDePago");
        }
        [GridAction]
        public ActionResult Select()
        {
            //ViewBag.proveedores = hotel_logica.retornar();
            return View("Index", new GridModel(tipodepago_logica.retornarTiposDePagos()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {
            TipoDePagoView tipodepago_view = new TipoDePagoView();
            if (TryUpdateModel(tipodepago_view))
            {
                tipodepago_logica.agregarTipoDePago(tipodepago_view);
            }
            return View("Index", new GridModel(tipodepago_logica.retornarTiposDePagos()));            
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int tipodepago_id = id ?? -1;
            tipodepago_logica.eliminarTipoDePago(tipodepago_id);
            return View("Index", new GridModel(tipodepago_logica.retornarTiposDePagos()));            
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TipoDePagoView p)
        {
            tipodepago_logica.modificarTipoDePago(p);
            return View("Index", new GridModel(tipodepago_logica.retornarTiposDePagos()));            
        }

    }
}
