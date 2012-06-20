using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using System.Threading;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class EntregaOCController : Controller
    {
        LogicaEntregaOC logica = new LogicaEntregaOC();
        //
        // GET: /AreaContable/EntragaOC/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult crearEntregaOC(int id_ordendecompra, int id_proveedor)
        {
            //faltan asignar parámetros para ViewBag
            return PartialView("EntregaOCPartial");
        }
        public ActionResult LineaOC(int id_oc)
        {
            Thread.Sleep(500);
            LogicaOrdenCompra oc = new LogicaOrdenCompra();
            return Json(new SelectList(oc.retornar_lineas(id_oc), "ID", "producto"));//falta poner RECIBIDOS/TOTAL
        }
        public ActionResult InsertEOCLinea(int id_eoc, int id_productoa, int cantidada)
        {
            try{
                logica.insertar_linea(id_eoc, id_productoa, cantidada);
                return Json(new { sms = "bien juga'o" });
            }
            catch (Exception e){
                return Json(new { sms = "mal pe'" });
            }
            
        }
    }
}
