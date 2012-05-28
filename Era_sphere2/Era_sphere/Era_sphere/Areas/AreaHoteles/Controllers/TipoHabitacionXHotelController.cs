using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.TipoHabitacionXHotel;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class TipoHabitacionXHotelController : Controller
    {

        // GET: /AreaHoteles/TipoHabitacionXHotel/
        InterfazLogicaTHXHotel logica_thXHotel = new LogicaTHXHotel();
        // 
        TipoHabitacionView thv = new PisoView();
        public ActionResult Index(int id)
        {
            /*List<PisoView> pisos = logica_piso.retornarPisos();
            if (pisos.Count() == 0)
                ViewData["nombre_hotel"] = "-";
            else
                ViewData["nombre_hotel"] = pisos[0].nombre_hotel;
            */

            ViewData["hotel"] = logica_piso.retornaNombreHotel(id);
            //TODO: eliminar la linea de arribita
            ViewData["hotelID"] = id;
            // List<PisoView> pisos = logica_piso.retornarPisos().Where(p => p.id_hotel == id).ToList();
            return View("IndexPiso");
        }



        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", new GridModel(logica_piso.retornarPisosDeHotel(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            PisoView piso_view = new PisoView();
            if (TryUpdateModel(piso_view))
            {
                piso_view.id_hotel = id;
                logica_piso.agregarPiso(piso_view);
            }
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id)));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int piso_id = id ?? -1;
            logica_piso.eliminarPiso(piso_id);
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id_hotel)));

        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(PisoView piso, int id_hotel)
        {

            logica_piso.modificarPiso(piso);
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id_hotel)));

        }
    }
}
