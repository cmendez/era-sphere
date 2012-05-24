using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TipoTemporadaController : Controller
    {

        InterfazLogicaTipoTemporada tipotemporada_logica = new LogicaTipoTemporada();
        public ActionResult Index()
        {
            return View("TipoTemporadaIndex");
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            TipoTemporadaView tipotemporada_view = new TipoTemporadaView();
            if (TryUpdateModel(tipotemporada_view))
            {
                tipotemporada_logica.agregarTipoTemporada(tipotemporada_view);

            }
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int tipotemporada_id = id ?? -1;
            tipotemporada_logica.eliminarTipoTemporada(tipotemporada_id);
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TipoTemporadaView p)
        {

            tipotemporada_logica.modificarTipoTemporada(p);
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }

    }
}
