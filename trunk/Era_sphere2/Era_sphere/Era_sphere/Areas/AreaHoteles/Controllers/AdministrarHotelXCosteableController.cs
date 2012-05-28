using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class AdministrarHotelXCosteableXTemporadaController : Controller
    {
        //
        // GET: /AreaHoteles/AdministrarHotelXCosteable/

        public ActionResult Index()
        {
            return View();
        }


        //
        //GET :/AreaHoteles/AdministrarHotelXCosteable/Administrar
        public ActionResult Administrar(int hxcID)
        {
            List<HotelXCosteableXTemporadaView> lhxcxtv = new LogicaHotelXCosteable.retornarCosteable(hxcID);
            return View("Index",lhxcxtv);

        }

    }
}
