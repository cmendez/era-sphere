using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HabitacionController : Controller
    {
        //
        // GET: /AreaHoteles/Habitacion/
        LogicaHabitacion habitacion_logica = new LogicaHabitacion();
        public ActionResult Index( int id )
        {
            Hotel hotel = (new EraSphereContext()).hoteles.Find(id);
            ViewData["id_hotel"] = id;
            ViewData["nombre_hotel"] = hotel.razon_social;
            return View("HabitacionIndex");
        }

        public ActionResult CrearMasivo(int id)
        {
            Hotel hotel = (new EraSphereContext()).hoteles.Find(id);
            ViewData["id_hotel"] = id;
            ViewData["nombre_hotel"] = hotel.razon_social;
            return View("CrearMasivo");
        }
        [GridAction]
        public ActionResult Select( int id_hotel )
        {
            return View("HabitacionIndex", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert( int id_hotel )
        {

            HabitacionView habitacion_view = new HabitacionView();
            if (TryUpdateModel(habitacion_view))
            {
                habitacion_logica.agregarHabitacion(habitacion_view);

            }
            return View("HabitacionIndex", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel( id_hotel )));
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id , int id_hotel )
        {
            int habitacion_id = id ?? -1;
            habitacion_logica.eliminarHabitacion(habitacion_id);
            return View("Index", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel( id_hotel )));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(HabitacionView p , int id_hotel )
        {

            habitacion_logica.modificarHabitacion(p);
            return View("HabitacionIndex", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel( id_hotel )));
        }
        /*[HttpPost]
        public ActionResult TiposHabitacionComboBox()
        {
            return Json(new SelectList(hotel_logica.retornarCiudades(id), "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }*/
        
    }
}
