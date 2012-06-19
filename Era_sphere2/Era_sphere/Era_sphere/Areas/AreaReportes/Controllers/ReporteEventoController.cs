using System;
using Era_sphere.Generics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportManagement;
using Era_sphere.Areas.AreaReportes.Models.ReporteEvento;
using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class ReporteEventoController : PdfViewController
    {
        //
        // GET: /AreaReportes/ReporteEvento/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarPDF()
        {
            string hotel, evento;
            int numAmb, numPart, numServ;
            decimal precioTotal;

            List<ReporteEvento> listareporteEvento = new List<ReporteEvento>();
            EraSphereContext context = new EraSphereContext();

            List<Evento> eventos = context.eventos.ToList();

            foreach (Evento e in eventos){
                hotel = context.hoteles.Find(e.hotel).razon_social;
                evento = e.nombre;
                numPart = e.participantes.Count;
                numAmb = e.eventoXAmbiente.Count;
                numServ = e.adicionales.Count;
                precioTotal = e.precio_total;

                ReporteEvento registro = new ReporteEvento(hotel, evento, numPart, numAmb, numServ, precioTotal);
                listareporteEvento.Add(registro);
            }            

            return this.ViewPdf("Reporte de Eventos", "ReporteEventoView", listareporteEvento);
        }
    }
}
