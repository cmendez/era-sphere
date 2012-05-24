using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TemporadaController : Controller
    {
        //
        // GET: /AreaConfiguracion/Temporada/

        InterfazLogicaTemporada temporada_logica = new LogicaTemporada();
        public ActionResult Index()
        {
            return View("TemporadaIndex", temporada_logica.retornarTemporadas());
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("TemporadaIndex", new GridModel(temporada_logica.retornarTemporadas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            TemporadaView temporada_view = new TemporadaView();
            if (TryUpdateModel(temporada_view))
            {
                temporada_logica.agregarTemporada(temporada_view);

            }
            return View("TemporadaIndex", new GridModel(temporada_logica.retornarTemporadas()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int temporada_id = id ?? -1;
            temporada_logica.eliminarTemporada(temporada_id);
            return View("TemporadaIndex", new GridModel(temporada_logica.retornarTemporadas()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TemporadaView p)
        {

            temporada_logica.modificarTemporada(p);
            return View("TemporadaIndex", new GridModel(temporada_logica.retornarTemporadas()));
        }

    }
}
