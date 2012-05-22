using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HabitacionController : Controller
    {
        //
        // GET: /AreaHoteles/Habitacion/
        InterfazLogicaHabitacion habitacion_logica = new LogicaHabitacion();
        public ActionResult Index()
        {
            return View("HabitacionIndex");
        }
        [GridAction]
        public ActionResult Select()
        {
            
            return View("Index", new GridModel(habitacion_logica.retornarHabitaciones()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            HabitacionView habitacion_view = new HabitacionView();
            if (TryUpdateModel(habitacion_view))
            {
                habitacion_logica.agregarHabitacion(habitacion_view);

            }
            return View("Index", new GridModel(habitacion_logica.retornarHabitaciones()));
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int habitacion_id = id ?? -1;
            habitacion_logica.eliminarHabitacion(habitacion_id);
            return View("Index", new GridModel(habitacion_logica.retornarHabitaciones()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(HabitacionView p)
        {

            habitacion_logica.modificarHabitacion(p);
            return View("Index", new GridModel(habitacion_logica.retornarHabitaciones()));
        }
        /*[HttpPost]
        public ActionResult TiposHabitacionComboBox()
        {
            return Json(new SelectList(hotel_logica.retornarCiudades(id), "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }*/
    }
}
