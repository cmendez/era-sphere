using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;

namespace Era_sphere.Areas.AreaReservas.Controllers
{
    public class ConsultaController : Controller
    {
        //
        // GET: /AreaReservas/Consulta/

        LogicaConsulta consulta_logica = new LogicaConsulta();

        public ActionResult Index()
        {
            return View("IndexConsulta");
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            
            
            return PartialView("IndexConsulta");//no segura :)


        }

    }
}
