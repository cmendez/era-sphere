using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

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
            int producto_id = id ?? -1;
            logicahp.eliminarProducto(id_hotel, producto_id);
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
    }
}
