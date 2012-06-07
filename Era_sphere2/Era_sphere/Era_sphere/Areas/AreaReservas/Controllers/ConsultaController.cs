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

        //ID : id del hotel
        public ActionResult Index(int ID, bool partial)
        {
            ViewData["partial"] = partial;
            return View("IndexConsulta", new ConsultaView { hotelID = ID });
        }

        
        public ActionResult Buscar(DateTime fecha_inicio, DateTime fecha_fin, int hotelID, int tipo_habitacionID, int pisoID)
        {
            Consulta resultado = new Consulta { fecha_inicio = fecha_inicio, fecha_fin = fecha_fin, hotelID = hotelID, pisoID = pisoID, tipo_habitacionID = tipo_habitacionID };
            consulta_logica.asignarHabitacionesDisponiblesTotales(resultado);
            return View("IndexConsulta", new ConsultaView(resultado));
        }

    }
}
