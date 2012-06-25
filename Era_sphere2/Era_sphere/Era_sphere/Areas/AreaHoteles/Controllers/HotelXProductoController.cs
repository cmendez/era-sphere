using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXProductoController : Controller
    {
        private LogicaHotelXProducto logicahp = new LogicaHotelXProducto();

        public ActionResult Index(int id)
        {
            ViewData["hotelID"] = id;
            ViewData["hotel"] = logicahp.retornaNombreHotel(id);
            return View(logicahp.retornarProductos(id));
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return View("Index", logicahp.retornarProductos(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int id)
        {
            HotelXProductoView hp_view = new HotelXProductoView(id);
            if (TryUpdateModel(hp_view))
            {
                logicahp.agregarProducto(id, hp_view);

            }
            return View("Index", new GridModel(logicahp.retornarProductos(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int hotelXProductoID = id ?? -1;
            logicahp.eliminarProducto(hotelXProductoID);
            return View("Index", new GridModel(logicahp.retornarProductos(id_hotel)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(HotelXProductoView hxpv, int id_hotel)
        {
            hxpv.hotelID = id_hotel;
            logicahp.modificarProducto(id_hotel, hxpv);
            return View("Index", new GridModel(logicahp.retornarProductos(id_hotel)));
        }

        [HttpPost]
        public JsonResult _GetProductos(int? linea_prodID)
        {
            //IQueryable<Temporada> ts = (new LogicaTemporada()).retornarTemporadas2();
            List<Producto> ps = (new EraSphereContext()).productos.ToList();
            ps = ps.Where(e => e.lineaProductoID == linea_prodID).ToList();
            return Json(new SelectList(ps, "ID", "descripcion"), JsonRequestBehavior.AllowGet);
        }
    }
}
