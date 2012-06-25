using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportManagement;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaReportes.Models.RepExcelCliente;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class RepExcelClienteController : Controller
    {
        //
        // GET: /AreaReportes/RepExcelCliente/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generar()
        {

            RepCliente reporte = new RepCliente();
            List<ObjetoReporteCliente> listaFinal = new List<ObjetoReporteCliente>();

            //
            List<ObjetoReporteCliente> listareporteCliente = new List<ObjetoReporteCliente>();
            EraSphereContext context = new EraSphereContext();
            List<Cliente> clientes = context.clientes.ToList();
            DateTime date = DateTime.Now;
            List<Cadena> cadena = (new EraSphereContext()).cadenas.ToList();

            foreach (Cliente c in clientes)
            {
                ObjetoReporteCliente registro = new ObjetoReporteCliente(c.nombre, c.documento_identidad, c.usuario, c.nombre, c.razon_social, c.tarjeta_cliente, c.habitacion_asignada, c.puntos_cliente, c.numero_reservas);
                listareporteCliente.Add(registro);
            }
            //

            reporte.titulo = new String[5, 7]
            {
                    {"","REPORTE DE","CLIENTES","", "", "",""},
                    {"","","","","","",""},
                    {"CADENA",cadena[0].nombreCadena,"","FECHA",date.ToShortDateString(),"",""},
                    {"","","","","","",""},
                    {"","","","","","",""}
            };

            reporte.cabecera = new String[1, 7]
                {
                    {"Nombre","Identificador","Usuairo", "Tarjeta del Cliente", "Habitación asignada", "Puntos", "Número de reservas"}                 
                };

            reporte.fileName = "ReporteCliente.xls";
            reporte.contenido = new String[100][];

            for (int i = 0; i < 100; i++)
                reporte.contenido[i] = new String[20];

            try
            {
                //llenamos el reporte
                for (int i = 0; i < listareporteCliente.Count; i++)
                {
                    reporte.contenido[i][0] = (listareporteCliente[i].nombre + listareporteCliente[i].razon_social);
                    reporte.contenido[i][1] = (listareporteCliente[i].ruc + listareporteCliente[i].documento_identidad);
                    reporte.contenido[i][2] = listareporteCliente[i].usuario;
                    reporte.contenido[i][3] = listareporteCliente[i].tarjeta_cliente;
                    reporte.contenido[i][4] = listareporteCliente[i].habitacion_asignada;
                    reporte.contenido[i][5] = listareporteCliente[i].puntos_cliente.ToString();
                    reporte.contenido[i][6] = listareporteCliente[i].numero_reservas.ToString();
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

            return View("RepExcelClienteView", reporte);
        }
    }
}
