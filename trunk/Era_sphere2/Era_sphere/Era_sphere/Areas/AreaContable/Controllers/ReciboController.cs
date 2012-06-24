using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Recibo;
namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ReciboController : Controller
    {
        EraSphereContext context = new EraSphereContext();
        //
        // GET: /AreaContable/Recibo/

        public ActionResult ReciboIndex(int reciboId, int hotelID)
        {
            Recibo r = context.recibos.Find(reciboId);
            ViewData["hotelID"] = hotelID;
            return PartialView("ReciboView", r);
        }
        public ActionResult VerRecibosReserva(int reservaID)
        {
            return PartialView("RecibosReserva", context.Reservas.Find(reservaID));
        }

    }
}
