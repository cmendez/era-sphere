using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Areas.AreaHoteles.Models;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXTipoHabitacionXTemporadaController : Controller
    {
        private LogicaHotelXTipoHabitacionXTemporada logicahtht = new LogicaHotelXTipoHabitacionXTemporada();

        public ActionResult Index(int id)
        {
            ViewData["hotelID"] = id;
            ViewData["hotel"] = (new EraSphereContext()).hoteles.Find(id).descripcion;
            return View(logicahtht.retornarTipoHabitacionsXTemporada(id));
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", logicahtht.retornarTipoHabitacionsXTemporada(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            HotelXTipoHabitacionXTemporadaView htht_view = new HotelXTipoHabitacionXTemporadaView(id);
            if (TryUpdateModel(htht_view))
            {
                if (htht_view.isValid())
                    logicahtht.agregarTipoHabitacionXTemporada(id, htht_view);

            }
            return View("Index", new GridModel(logicahtht.retornarTipoHabitacionsXTemporada(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int tipoHabitacionXTemporada_id = id ?? -1;
            logicahtht.eliminarTipoHabitacionXTemporada(id_hotel, tipoHabitacionXTemporada_id);
            return View("Index", new GridModel(logicahtht.retornarTipoHabitacionsXTemporada(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(HotelXTipoHabitacionXTemporadaView hxthxtv, int id_hotel)
        {
            hxthxtv.hotelID = id_hotel;
            if (hxthxtv.isValid())
                logicahtht.modificarTipoHabitacionXTemporada(id_hotel, hxthxtv);
            return View("Index", new GridModel(logicahtht.retornarTipoHabitacionsXTemporada(id_hotel)));
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

        public JsonResult _GetCostoBase(int? tipohabitacionID)
        {
            List<decimal> cb = new List<decimal>();
            cb.Add( (new EraSphereContext()).tipos_habitacion.Find(tipohabitacionID).costo_base );
            return Json(new SelectList(cb), JsonRequestBehavior.AllowGet);
        }
       

    }
}
