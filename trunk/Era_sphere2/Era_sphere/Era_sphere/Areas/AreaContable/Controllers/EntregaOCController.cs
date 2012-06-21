﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using System.Threading;
using Telerik.Web.Mvc;

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
            ViewBag.proveedor = (new LogicaProveedor()).retornarProveedor(id_proveedor);
            ViewBag.entregaoc = logica.crearEOC(id_ordendecompra);
            ViewBag.oc = (new LogicaOrdenCompra()).retornar_orden(id_ordendecompra);
            return PartialView("EntregaOCPartial");
        }
        public ActionResult LineaOCRestante(int id_oc)
        {
            Thread.Sleep(500);
            return Json(new SelectList(logica.retornar_lineas_restantes(id_oc), "ID", "descripcion"));//falta poner RECIBIDOS/TOTAL
        }
        public ActionResult InsertEOCL(int id_eoc, int id_productoa, int cantidada)
        {
            try{
                logica.insertar_linea(id_eoc, id_productoa, cantidada);
                return Json(new { msg = "ok" });
            }
            catch (Exception e){
                return Json(new { msg = e.Message });
            }
            
        }
        [GridAction]
        public ActionResult SelectEOCL(int id_eoc) {
            List<EOCLineaView> ans = logica.retornar_entrega_lineas(id_eoc);
            return View("OrdenesAceptadasPartial", new GridModel( ans ) );
        }
        [GridAction]
        public ActionResult DeleteEOCL(int id) {
            string msg = "ok";
            try { logica.elimina_entrega_linea(id); }
            catch (Exception ex) { msg = ex.Message; }
            return Json( new { msg = msg });
        }

        [GridAction]
        public ActionResult UpdateEOCL(EOCLineaView entrega_linea) { 
            string msg = "ok";
            try{
            logica.modificar_entrega_linea( entrega_linea );
            } catch( Exception ex ){ msg = ex.Message; }
            return Json( new { msg = msg }); 
        }

        public ActionResult DeleteEOC(int id_eoc) {
            string msg = "ok";
            try { logica.eliminar_entrega(id_eoc); }
            catch (Exception e) { msg = e.Message;  }
            return Json(new { msg = msg });
        }

        public ActionResult DetalleOC( int id_oc ){
            ViewBag.oc = (new LogicaOrdenCompra()).retornar_orden(id_oc);
            return PartialView();
        }
        [GridAction]
        public ActionResult SelectEntregas(int id_oc) {
            List<EntregaOCView> entregas = logica.retornar_entregas(id_oc);
            return View(new GridModel( entregas ));
        }
        [GridAction]
        public ActionResult DeleteEntrega(int id_oc) {
            logica.eliminar_entrega(id_oc);
            return View(new GridModel());
        }

        public ActionResult DetalleEOC(int id_eoc) {
            var eoc = logica.retornar_entrega(id_eoc);
            return Json(new { eoc = eoc});
        }
    }
}
