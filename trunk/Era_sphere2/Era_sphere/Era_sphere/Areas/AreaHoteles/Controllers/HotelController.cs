using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /AreaHoteles/Hotel/

        public ActionResult Index()
        {
            return View("IndexHotel");
        }

    }
}
