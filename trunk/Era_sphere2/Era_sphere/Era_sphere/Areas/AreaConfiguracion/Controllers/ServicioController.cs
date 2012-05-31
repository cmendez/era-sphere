﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;


namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class ServicioController : Controller
    {
        //
        // GET: /AreaConfiguracion/Temporada/

        InterfazLogicaServicios servicios_logica = new LogicaServicios();
        public ActionResult Index()
        {
            return View("ServiciosIndex", servicios_logica.retornarServicios());
        }
        [GridAction]
        public ActionResult Select()
        {
            return View("ServiciosIndex", new GridModel(servicios_logica.retornarServicios()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            ServicioView servicio_view = new ServicioView();
            if (TryUpdateModel(servicio_view))
            {
                servicios_logica.agregarServicio(servicio_view);

            }
            return View("ServiciosIndex", new GridModel(servicios_logica.retornarServicios()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int servicio_id = id ?? -1;
            servicios_logica.eliminarServicio(servicio_id);
            return View("ServiciosIndex", new GridModel(servicios_logica.retornarServicios()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ServicioView p)
        {

            servicios_logica.modificarServicio(p);
            return View("ServiciosIndex", new GridModel(servicios_logica.retornarServicios()));
        }

    }
}
