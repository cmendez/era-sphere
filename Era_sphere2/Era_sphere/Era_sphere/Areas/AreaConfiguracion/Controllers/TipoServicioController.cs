using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using System.Web.Helpers;


namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TipoServicioController : Controller
    {
        //
        // GET: /AreaConfiguracion/Temporada/

        LogicaServicios servicios_logica = new LogicaServicios();
        public ActionResult Index()
        {
            return View("TipoServiciosIndex");
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("TipoServiciosIndex", new GridModel(servicios_logica.retornarTipoServicios()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            TipoServicioView tipo_servicio_view = new TipoServicioView();
            if (TryUpdateModel(tipo_servicio_view))
            {
                servicios_logica.agregarTipoServicio(tipo_servicio_view);

            }
            return View("TipoServiciosIndex", new GridModel(servicios_logica.retornarTipoServicios()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int servicio_id = id ?? -1;
            servicios_logica.eliminarTipoServicio(servicio_id);
            return View("TipoServiciosIndex", new GridModel(servicios_logica.retornarTipoServicios()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TipoServicioView p)
        {

            servicios_logica.modificarTipoServicio(p.deserializa(servicios_logica));
            return View("TipoServiciosIndex", new GridModel(servicios_logica.retornarTipoServicios()));
        }

        public JsonResult ObtieneTipo(int tipo_id)
        {
            return Json(new { tipo = new TipoServicioView(servicios_logica.context.tipo_servicios.Find(tipo_id)) });
        }
    }
}
