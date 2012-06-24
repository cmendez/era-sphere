using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Generics;
using ReportManagement;
using Era_sphere.Areas.AreaPromociones.Models;
using Era_sphere.Areas.AreaReportes.Models.RepExcelPromocion;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class RepExcelPromocionController : Controller
    {
        //
        // GET: /AreaReportes/RepExcelPromocion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generar()
        {

            RepPromocion reporte = new RepPromocion();
            List<ObjetoReportePromocion> listaFinal = new List<ObjetoReportePromocion>();

            //
            List<ObjetoReportePromocion> listareportePromocion = new List<ObjetoReportePromocion>();
            EraSphereContext context = new EraSphereContext();
            List<Promocion> promociones = context.promociones.ToList();

            foreach (Promocion p in promociones)
            {
                ObjetoReportePromocion registro = new ObjetoReportePromocion(p.nombre, p.descripcion, p.puntos_requeridos, p.descuento, p.fecha_inicio, p.fecha_fin, p.hotelID);
                listareportePromocion.Add(registro);
            }
            //

            reporte.cabecera = new String[2, 7]
                {
                    {"Nombre","Descripción","Puntos requeridos", "Descuento", "Fecha de inicio", "Fecha de fin", "Asociado a"},
                    {"","","","","","",""}
                 
                };

            reporte.fileName = "ReportePromocion.xls";
            reporte.contenido = new String[100][];

            for (int i = 0; i < 100; i++)
                reporte.contenido[i] = new String[20];

            try
            {
                //llenamos el reporte
                for (int i = 0; i < listareportePromocion.Count; i++)
                {
                    string format = "dd/MM/yyyy";
                    reporte.contenido[i][0] = listareportePromocion[i].nombre;
                    reporte.contenido[i][1] = listareportePromocion[i].descripcion;
                    reporte.contenido[i][2] = listareportePromocion[i].puntos_requeridos.ToString();
                    reporte.contenido[i][3] = listareportePromocion[i].descuento.ToString();
                    reporte.contenido[i][4] = listareportePromocion[i].fecha_inicio.ToString(format);
                    reporte.contenido[i][5] = listareportePromocion[i].fecha_fin.ToString(format);
                    reporte.contenido[i][6] = listareportePromocion[i].relacionpromocion;
                }

            }
            catch
            {
                for (int i = 10; i < 20; i++)
                {
                    reporte.contenido[i][0] = "ERROR";
                    reporte.contenido[i][1] = "EN LA";
                    reporte.contenido[i][2] = "GENERACION";
                    reporte.contenido[i][3] = "DEL";
                    reporte.contenido[i][4] = "REPORTE";
                    reporte.contenido[i][5] = "!!!!";
                }
            }

            return View("RepExcelPromocionView", reporte);
        }



    }
}
