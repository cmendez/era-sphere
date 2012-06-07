using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /AreaHoteles/Hotel/
        InterfazLogicaHotel hotel_logica = new LogicaHotel();
        public ActionResult Index()
        {
            return View("IndexHotel");
        }

        [GridAction]
        public ActionResult Select()
        {
            //ViewBag.proveedores = hotel_logica.retornar();
            return View("Index", new GridModel( hotel_logica.retornarHoteles()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            HotelView hotel_view = new HotelView();
            if (TryUpdateModel(hotel_view))
            {
                hotel_logica.agregarHotel(hotel_view);

            }
            return View("Index", new GridModel(hotel_logica.retornarHoteles()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int hotel_id = id ?? -1;
            hotel_logica.eliminarHotel(hotel_id);
            return View("Index", new GridModel(hotel_logica.retornarHoteles()));
            //return RedirectToAction("proveedor");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(HotelView p)
        {

            hotel_logica.modificarHotel(p);
            return View("Index", new GridModel(hotel_logica.retornarHoteles()));
            // return RedirectToAction("proveedor");
        }

        [HttpPost]
        public ActionResult CiudadesComboBox( int? pais_id ) {
            int id = pais_id ?? -1;
            return Json( new SelectList( hotel_logica.retornarCiudades( id ) , "ID" , "nombre" ), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult _GetComboBoxCiudades(int? paisID)
        {
            return _GetCiudades(paisID);
        }

        private JsonResult _GetCiudades(int? paisID)
        {
            //IQueryable<Temporada> ts = (new LogicaTemporada()).retornarTemporadas2();
            List<Ciudad> cs = (new EraSphereContext()).paises.Find(paisID).ciudades.ToList();
            return Json(new SelectList(cs, "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult _GetComboBoxProvincias(int? ciudadID)
        {
            return _GetProvincias(ciudadID);
        }

        private JsonResult _GetProvincias(int? ciudadID)
        {
            //IQueryable<Temporada> ts = (new LogicaTemporada()).retornarTemporadas2();
            List<Provincia> ps = (new EraSphereContext()).ciudades.Find(ciudadID).provincias.ToList();
            return Json(new SelectList(ps, "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }

    }
}
