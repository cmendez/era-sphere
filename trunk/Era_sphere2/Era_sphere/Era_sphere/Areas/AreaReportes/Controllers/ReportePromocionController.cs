using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportManagement;
using Era_sphere.Areas.AreaPromociones.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaReportes.Models.ReportePromocion;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class ReportePromocionController : PdfViewController
    {
        //
        // GET: /AreaReportes/ReportePromocion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarPDF() 
        {
            //string nombre, descripcion;
            //int puntos_requeridos, descuento;
            //DateTime fecha_inicio, fecha_fin;
            //int relacionpromocionID;

            List<ReportePromocion> listareportePromocion = new List<ReportePromocion>();
            EraSphereContext context = new EraSphereContext();
            List<Promocion> promociones = new List<Promocion>();
            promociones = context.promociones.ToList();

            foreach(Promocion p in promociones){
                //nombre = p.nombre;
                //descripcion = p.descripcion;
                //puntos_requeridos = p.puntos_requeridos;
                //descuento = p.descuento;
                //fecha_inicio = p.fecha_inicio;
                //fecha_fin = p.fecha_fin;
                //relacionpromocionID = p.relacionpromocionID;

                ReportePromocion registro = new ReportePromocion(p.nombre, p.descripcion, p.puntos_requeridos, p.descuento, p.fecha_inicio, p.fecha_fin, p.relacionpromocionID);
                listareportePromocion.Add(registro);
            }
            return this.ViewPdf("Reporte de Promociones", "ReportePromocionView", listareportePromocion);
        }

    }
}
