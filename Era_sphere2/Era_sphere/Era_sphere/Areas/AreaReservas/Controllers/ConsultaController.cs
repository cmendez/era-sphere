using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReservas.Models;
using System.Web.Helpers;
using Era_sphere.Areas.AreaHoteles.Models;

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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Buscar(DateTime fecha_inicio, DateTime fecha_fin, int hotelID, int tipo_habitacionID, int pisoID, bool partial)
        {
            Consulta resultado = new Consulta { fecha_inicio = fecha_inicio, fecha_fin = fecha_fin, hotelID = hotelID, pisoID = pisoID, tipo_habitacionID = tipo_habitacionID };
            consulta_logica.asignarHabitacionesDisponiblesTotales(resultado);
            ViewData["partial"] = partial;
            return PartialView("GridResultConsulta", new ConsultaView(resultado));
        }
        //tipo_habitacionID puede ser 0, si lo es, busca en todo
        public JsonResult BuscarHabitaciones(DateTime fecha_inicio, DateTime fecha_fin, int hotelID, int tipo_habitacionID)
        {
            Consulta resultado = new Consulta { fecha_inicio = fecha_inicio, fecha_fin = fecha_fin, hotelID = hotelID, pisoID = 0, tipo_habitacionID = tipo_habitacionID };
            consulta_logica.asignarHabitacionesDisponiblesTotales(resultado);
            List<object> lista = new List<object>();
            resultado.habitaciones_resultantes.ForEach(x => lista.Add(new { habitacion_id = x.ID, tipo_habitacion_id = x.tipoHabitacionID, nombre = x.detalle }));
            return Json(new { habitaciones = lista });
        }

        public JsonResult DetalleHabitacion(int habitacionID)
        {
            HabitacionView view = new HabitacionView(consulta_logica.context.habitaciones.Find(habitacionID));
            return Json(new { habitacion = view });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubConsulta(List<int> hab_ids, int hotel_id)
        {
            hab_ids = hab_ids ?? new List<int>();
            Consulta res = new Consulta();
            res.hotelID = hotel_id;
            res.habitaciones_resultantes = consulta_logica.context.habitaciones.Where(p => hab_ids.Contains(p.ID)).ToList();
            return PartialView("GridResultAcumulado", new ConsultaView(res));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SubConsultaPrecio(List<int> hab_ids, int hotel_id, DateTime fecha_inicio, DateTime fecha_fin)
        {
            hab_ids = hab_ids ?? new List<int>();
            var habitaciones_resultantes = consulta_logica.context.habitaciones.Where(p => hab_ids.Contains(p.ID)).ToList();
            decimal costo_inicial = 0;
            foreach (var h in habitaciones_resultantes)
                costo_inicial += (new TipoHabitacionView(h.tipoHabitacion, hotel_id)).costo;
            TimeSpan span = fecha_fin - fecha_inicio;
            int dias = (int)(Math.Ceiling((double)(span.Days)));
            costo_inicial *= (decimal)(dias);
            decimal precio_derecho_reserva = consulta_logica.context.cadenas.ToList()[0].adel_minimo / 100.0m * costo_inicial;
            return Json(new { costo_inicial = costo_inicial, precio_derecho_reserva = precio_derecho_reserva, dias_estadia = dias });
        }
        public JsonResult Nada(int id)
        {
            return Json(new { id = id }, JsonRequestBehavior.AllowGet);
        }

    }
}
