using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Generics;
using ReportManagement;
using Era_sphere.Areas.AreaEventos.Models.Evento;
using Era_sphere.Areas.AreaReportes.Models.RepExcelEvento;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class RepExcelEventoController : Controller
    {
        //
        // GET: /AreaReportes/RepExcelEvento/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Generar()
        {

            RepEvento reporte = new RepEvento();
            List<ObjetoReporteEvento> listaFinal = new List<ObjetoReporteEvento>();

            //
            List<ObjetoReporteEvento> listareporteEvento = new List<ObjetoReporteEvento>();
            EraSphereContext context = new EraSphereContext();
            List<Evento> eventos = context.eventos.ToList();
            DateTime date = DateTime.Now;
            List<Cadena> cadena = (new EraSphereContext()).cadenas.ToList();

            foreach (Evento e in eventos)
            {
                ObjetoReporteEvento registro = new ObjetoReporteEvento(e.fecha_inicio, context.hoteles.Find(e.hotel).razon_social,  e.nombre, e.participantes.Count, e.eventoXAmbiente.Count, e.evento_servicios.Count, e.precio_total);
                listareporteEvento.Add(registro);
            }
            //

            reporte.titulo = new String[5, 6]
            {
                    {"","REPORTE DE","EVENTOS","","",""},
                    {"","","","","",""},
                    {"CADENA",cadena[0].nombreCadena,"","FECHA",date.ToShortDateString(),""},
                    {"","","","","",""},
                    {"","","","","",""}
            };

            reporte.cabecera = new String[1, 7]
                {
                    {"Hotel", "Fecha de inicio", "Evento","Número de Participantes", "Número de Ambientes", "Número de Servicios", "Precio Total"},
                };

            //   {x.ToString(),s,y.ToString(),"fin XD"}

            reporte.fileName = "ReporteEventos.xls";
            reporte.contenido = new String[100][];

            for (int i = 0; i < 100; i++)
                reporte.contenido[i] = new String[20];
            
            try
            {
                //llenamos el reporte
                for (int i = 0; i < listareporteEvento.Count; i++)
                {
                    string formato = "dd/mm/yyyy";
                    reporte.contenido[i][0] = listareporteEvento[i].hotel;
                    reporte.contenido[i][1] = listareporteEvento[i].fecha_inicio.ToString(formato);
                    reporte.contenido[i][2] = listareporteEvento[i].evento;
                    reporte.contenido[i][3] = listareporteEvento[i].numAmb.ToString();
                    reporte.contenido[i][4] = listareporteEvento[i].numPart.ToString();
                    reporte.contenido[i][5] = listareporteEvento[i].numServ.ToString();
                    reporte.contenido[i][6] = listareporteEvento[i].precioTotal.ToString();
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

            return View("RepExcelEventoView", reporte);
        }

    }
}
