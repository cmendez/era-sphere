using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaHoteles.Models.HotelXCosteableXTemporadaNM;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelXCosteableXTemporadaController : Controller
    {
        //
        // GET: /AreaHoteles/HotelXCosteableXTemporada/

        private LogicaHotelXCosteableXTemporada logicahct;

        public ActionResult Index(int id)
        {
            this.logicahct = new LogicaHotelXCosteableXTemporada(id);
            return View(logicahct.retornarCosteablesXTemporada());
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            return null;
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert()
        {
            return null;
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete()
        {
            return null;
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update()
        {
            return null;
        }

    }
}
