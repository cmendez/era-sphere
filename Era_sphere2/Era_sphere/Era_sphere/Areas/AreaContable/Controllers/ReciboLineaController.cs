using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ReciboLineaController : Controller
    {
        //
        // GET: /AreaContable/ReciboLinea/

        public ActionResult Index()
        {
            return View("IndexReciboLinea");
        }

        public ActionResult ReciboLineaServicio(ICollection<ReciboLinea> recibos)
        {
            return View();
        }

        public ActionResult ReciboReserva(ICollection<ReciboLinea> recibos)
        {
            return View();
        }

        public ActionResult ReciboLineaEvento(ICollection<ReciboLinea> recibos)
        {
            return View();
        }
    }
}
