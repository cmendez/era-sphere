using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using ReportManagement;
namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class ReciboController : PdfViewController
    {
        EraSphereContext context = new EraSphereContext();
        //
        // GET: /AreaContable/Recibo/

        public ActionResult ReciboIndex(int reciboId, int hotelID)
        {
            Recibo r = context.recibos.Find(reciboId);
            ViewData["hotelID"] = hotelID;
            ViewData["reciboId"] = reciboId;
            return PartialView("ReciboView", r);
        }

        public ActionResult ReciboEvento(int reciboId,int hotelID)
        {
            Recibo r = context.recibos.Find(reciboId);
            ViewData["hotelID"] = hotelID;
            ViewData["reciboId"] = reciboId;
            return PartialView("ReciboEventoView", r);
        }
        public ActionResult VerRecibosReserva(int reservaID)
        {
            return PartialView("RecibosReserva", context.Reservas.Find(reservaID));
        }
        public ActionResult ReciboPDF(int reciboId, int hotelID) 
        {
            Recibo r = context.recibos.Find(reciboId);
            r.auxID = hotelID;
            return this.ViewPdf("","ReciboPDF", r);
        }
        public ActionResult ReciboEventoPDF(int reciboId, int hotelID)
        {
            Recibo r = context.recibos.Find(reciboId);
            r.auxID = hotelID;
            return this.ViewPdf("", "ReciboEventoPDF", r);
        }

    }
}
