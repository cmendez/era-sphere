using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class PisoController : Controller
    {
        
        // GET: /AreaHoteles/Piso/
        InterfazLogicaPiso logica_piso = new LogicaPiso();
        // 
        PisoView piso = new PisoView();
        public ActionResult Index()
        {
            /*List<PisoView> pisos = logica_piso.retornarPisos();
            if (pisos.Count() == 0)
                ViewData["nombre_hotel"] = "-";
            else
                ViewData["nombre_hotel"] = pisos[0].nombre_hotel;
            */

            ViewData["HOTEL"] = logica_piso.retornaNombreHotel(piso.id_hotel);
            //TODO: eliminar la linea de arribita
     
            return View("IndexPiso");
        }

        

        [GridAction]
        public ActionResult select()
        {
            return View("Index", new GridModel(logica_piso.retornarPisos()));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert()
        {
            PisoView piso_view = new PisoView();
            if (TryUpdateModel(piso_view))
            {
                logica_piso.agregarPiso(piso_view);
            }
            return View("Index", new GridModel(logica_piso.retornarPisos()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id)
        {
            int piso_id = id ?? -1;
            logica_piso.eliminarPiso(piso_id);
            return View("Index", new GridModel(logica_piso.retornarPisos()));
    
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(PisoView piso)
        {

            logica_piso.modificarPiso(piso);
            return View("Index", new GridModel(logica_piso.retornarPisos()));
     
        }
    }
}
