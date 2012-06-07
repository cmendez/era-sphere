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
    public class HotelXServicioXTemporadaController : Controller
    {
        private LogicaHotelXServicioXTemporada logicahpt = new LogicaHotelXServicioXTemporada();

        public ActionResult Index(int id)
        {
            ViewData["hotelID"] = id;
            ViewData["hotel"] = logicahpt.retornaNombreHotel(id);
            return View(logicahpt.retornarServiciosXTemporada(id));
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", logicahpt.retornarServiciosXTemporada(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            HotelXServicioXTemporadaView hpt_view = new HotelXServicioXTemporadaView(id);
            if (TryUpdateModel(hpt_view))
            {
                logicahpt.agregarServicioXTemporada(id, hpt_view);

            }
            return View("Index", new GridModel(logicahpt.retornarServiciosXTemporada(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int servicioXTemporada_id = id ?? -1;
            logicahpt.eliminarServicioXTemporada(id_hotel, servicioXTemporada_id);
            return View("Index", new GridModel(logicahpt.retornarServiciosXTemporada(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(HotelXServicioXTemporadaView hstv, int id_hotel)
        {
            hstv.hotelID = id_hotel;
            logicahpt.modificarServicioXTemporada(id_hotel, hstv);
            return View("Index", new GridModel(logicahpt.retornarServiciosXTemporada(id_hotel)));
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
            return Json(new SelectList(ts, "ID", "razon_social"), JsonRequestBehavior.AllowGet);
        }

    }
}
