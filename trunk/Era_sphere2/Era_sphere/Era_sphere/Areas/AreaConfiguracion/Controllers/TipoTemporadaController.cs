using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TipoTemporadaController : Controller
    {
        
        InterfazLogicaTipoTemporada logica_tipotemporada = new LogicaTipoTemporada();
        // 
        TipoTemporadaView piso = new TipoTemporadaView();
        public ActionResult Index()
        {
            return View("IndexTipoTemporada");
        }

        
        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", new GridModel(logica_piso.retornarPisoHotel(id)));
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
            return View("IndexPiso", new GridModel(logica_piso.retornarPisoHotel(id)));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int piso_id = id ?? -1;
            logica_piso.eliminarPiso(piso_id);
            return View("IndexPiso", new GridModel(logica_piso.retornarPisoHotel(id_hotel)));

        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(PisoView piso, int id_hotel)
        {

            logica_piso.modificarPiso(piso);
            return View("IndexPiso", new GridModel(logica_piso.retornarPisoHotel(id_hotel)));

        }

    }
}
