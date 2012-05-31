using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXPreciableXTemporadaController : Controller
    {
        //
        // GET: /AreaHoteles/HotelXPreciableXTemporada/

        private LogicaHotelXPreciableXTemporada logicahpt = new LogicaHotelXPreciableXTemporada();

        public ActionResult Index(int id)
        {
            ViewData["hotelID"] = id;
            ViewData["hotel"] = logicahpt.retornaNombreHotel(id);
            return View(logicahpt.retornarPreciablesXTemporada(id));
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("IndexHotelXPreciableXTemporada", logicahpt.retornarPreciablesXTemporada(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            HotelXPreciableXTemporadaView hpt_view = new HotelXPreciableXTemporadaView();
            if (TryUpdateModel(hpt_view))
            {
                logicahpt.agregarPreciableXTemporada(id,hpt_view);

            }
            return View("Index", new GridModel(logicahpt.retornarPreciablesXTemporada(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int preciableXTemporada_id = id ?? -1;
            logicahpt.eliminarPreciableXTemporada(id_hotel, preciableXTemporada_id);
            return View("Index", new GridModel(logicahpt.retornarPreciablesXTemporada(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(HotelXPreciableXTemporadaView p, int id_hotel)
        {
            logicahpt.modificarPreciableXTemporada(id_hotel,p);
            return View("Index", new GridModel(logicahpt.retornarPreciablesXTemporada(id_hotel)));
        }

        [HttpPost]
        public JsonResult _GetDropDownListTemporadas(int? DropDownList_tipoTemporada)
        {
            return _GetTemporadas(DropDownList_tipoTemporada);
        }

        private JsonResult _GetTemporadas(int? tipoTemporadaID)
        {
            //IQueryable<Temporada> ts = (new LogicaTemporada()).retornarTemporadas2();
            List<Temporada> ts = (new LogicaTemporada()).retornarTemporadas2();
            ts.Where(e => e.tipotemporadaID == tipoTemporadaID);
            return Json(new SelectList(ts,"ID","descripcion"),JsonRequestBehavior.AllowGet);
        }
    }
}
