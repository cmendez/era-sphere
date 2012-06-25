using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXTipoServicioXTemporadaController : Controller
    {
        private LogicaHotelXTipoServicioXTemporada logicahpt = new LogicaHotelXTipoServicioXTemporada();

        public ActionResult Index(int id)
        {
            ViewData["hotelID"] = id;
            ViewData["hotel"] = logicahpt.retornaNombreHotel(id);
            return View(logicahpt.retornarTipoServiciosXTemporada(id));
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", logicahpt.retornarTipoServiciosXTemporada(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            HotelXTipoServicioXTemporadaView hpt_view = new HotelXTipoServicioXTemporadaView(id);
            if (TryUpdateModel(hpt_view))
            {
                logicahpt.agregarServicioXTemporada(id, hpt_view);

            }
            return View("Index", new GridModel(logicahpt.retornarTipoServiciosXTemporada(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int id2 = id ?? -1;
            logicahpt.eliminarServicioXTemporada(id2);
            return View("Index", new GridModel(logicahpt.retornarTipoServiciosXTemporada(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(HotelXTipoServicioXTemporadaView hstv, int id_hotel)
        {
            hstv.hotelID = id_hotel;
            logicahpt.modificarTipoServicioXTemporada(id_hotel, hstv);
            return View("Index", new GridModel(logicahpt.retornarTipoServiciosXTemporada(id_hotel)));
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
            ts = ts.Where(e => e.tipotemporadaID == tipoTemporadaID).ToList();
            return Json(new SelectList(ts, "ID", "descripcion"), JsonRequestBehavior.AllowGet);
        }

    }
}
