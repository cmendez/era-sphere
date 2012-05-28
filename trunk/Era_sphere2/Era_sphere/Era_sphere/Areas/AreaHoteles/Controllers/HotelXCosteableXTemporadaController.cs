using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXCosteable;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXCosteableXTemporadaController : Controller
    {
        //
        // GET: /AreaHoteles/HotelXCosteableXTemporada/

        private LogicaHotelXCosteable logicaHotelXCosteable;

        public ActionResult Index(int id)
        {
            this.logicaHotelXCosteableXTemporada = new LogicaHotelXCosteableXTemporada(id);
            return View(logicaHotelXCosteable.retornarCosteables());
        }

    }
}
