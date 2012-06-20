using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportManagement;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Generics;


namespace Era_sphere.Controllers
{
    public class PDFController : PdfViewController
    {
        //
        // GET: /PDF/

        public ActionResult Index()
        {


            return View();
        }

        public ActionResult MostrarPDF()
        {
            
        EraSphereContext tipotemporada_context = new EraSphereContext();
        DBGenericQueriesUtil<TipoTemporada> database_table;

        database_table = new DBGenericQueriesUtil<TipoTemporada>(tipotemporada_context, tipotemporada_context.tipostemporada);

        List<TipoTemporada> tipostemporada = database_table.retornarTodos();
        
            return this.ViewPdf("PDF", "PDFView", tipostemporada);
        }
        
    }
}
