using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class TipoHabitacionController : Controller
    {
        //
        // GET: /AreaHoteles/TipoHabitacion/
        InterfazLogicaTipoHabitacion tipoHabitacion_logica = new LogicaTipoHabitacion();
        public ActionResult Index()
        {
            return View();
        }
        [GridAction]
        public ActionResult Select()
        {
            //ViewBag.proveedores = hotel_logica.retornar();
            return View("Index", new GridModel(tipoHabitacion_logica.retornarTiposHabitacion()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            TipoHabitacionView tipoHabitacion_view = new TipoHabitacionView();
            if (TryUpdateModel(tipoHabitacion_view))
            {
                tipoHabitacion_logica.agregarTipoHabitacion(tipoHabitacion_view);

            }
            return View("Index", new GridModel(tipoHabitacion_logica.retornarTiposHabitacion()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int tipoHabitacion_id = id ?? -1;
            tipoHabitacion_logica.eliminarTipoHabitacion(tipoHabitacion_id);
            return View("Index", new GridModel(tipoHabitacion_logica.retornarTiposHabitacion()));
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TipoHabitacionView p)
        {

            tipoHabitacion_logica.modificarTipoHabitacion(p);
            return View("Index", new GridModel(tipoHabitacion_logica.retornarTiposHabitacion()));
        }


    }
}
