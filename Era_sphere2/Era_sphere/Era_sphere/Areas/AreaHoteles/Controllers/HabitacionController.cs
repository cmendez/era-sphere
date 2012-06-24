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

        //[AcceptVerbs(HttpVerbs.Post)]
        //[GridAction]
        //public ActionResult Update(HabitacionView p , int id_hotel )
        //{

        //    habitacion_logica.modificarHabitacion(p);
        //    return View("HabitacionIndex", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel( id_hotel )));
        //}
        /*[HttpPost]
        public ActionResult TiposHabitacionComboBox()
        {
            return Json(new SelectList(hotel_logica.retornarCiudades(id), "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }*/

        [GridAction]
        public ActionResult Update(int id_hotel, IEnumerable<HabitacionView> inserted, IEnumerable<HabitacionView> updated, IEnumerable<HabitacionView> deleted)
        {
            if (inserted != null)
            {
                foreach (var hab_view in inserted)
                {
                    if (TryUpdateModel(hab_view))
                    {
                        habitacion_logica.agregarHabitacion(hab_view);
                    }
                }
            }

            if (updated != null)
            {
                foreach (var hab_view in updated)
                {
                    habitacion_logica.modificarHabitacion(hab_view);
                }
            }

            if (deleted != null)
            {
                foreach (var hab_view in deleted)
                {
                    habitacion_logica.eliminarHabitacion(hab_view.ID);
                }
            }
            return View("IndexPiso", new GridModel(habitacion_logica.retornarHabitacionesViewDeHotel(id_hotel)));
        }

        [HttpPost]
        public ActionResult _GetPisos(int hotel_id)
        {
            List<Piso> pss = habitacion_logica.retornarPisos(hotel_id);
            return new JsonResult { Data = new SelectList(pss, "ID", "cod_con_descripcion") };
        }

        [HttpPost]
        public ActionResult _GetTipoHabitaciones(int hotel_id)
        {
            IEnumerable<TipoHabitacion> thabs = habitacion_logica.retornarTiposHabitacion(hotel_id);
            return new JsonResult { Data = new SelectList(thabs, "ID", "descripcion") };
        }
        
    }
}
