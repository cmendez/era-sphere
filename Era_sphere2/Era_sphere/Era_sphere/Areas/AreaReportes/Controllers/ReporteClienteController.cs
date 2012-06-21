using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Generics;
using ReportManagement;
using Era_sphere.Areas.AreaReportes.Models.ReporteCliente;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class ReporteClienteController : PdfViewController
    {
        //
        // GET: /AreaReportes/ReporteCliente/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarPDF() 
        {

            List<ReporteCliente> listareporteCliente = new List<ReporteCliente>();
            EraSphereContext context = new EraSphereContext();

            List<Cliente> clientes = context.clientes.ToList();

            foreach (Cliente c in clientes)
            {
                
                ReporteCliente registro = new ReporteCliente(c.ruc, c.documento_identidad, c.usuario, c.nombre, c.razon_social, c.tarjeta_cliente, c.habitacion_asignada, c.puntos_cliente, c.numero_reservas);
                listareporteCliente.Add(registro);
            }        

            return ViewPdf("Reporte de Clientes", "ReporteClienteView", listareporteCliente);
        }

    }
}
