using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using System.IO;
//using NPOI.HSSF.UserModel;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class AdministrarOCController : Controller
    {
        //
        // GET: /AreaContable/AdministrarOC/
        LogicaOrdenCompra logica = new LogicaOrdenCompra();
        public ActionResult Index()
        {            
            return View();
        }


        #region Administrar Orden

        [GridAction]
        ActionResult default_admin(int id_hotel)
        {
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra(id_hotel)));
        }
        public ActionResult IndexAdministracion(int id)
        {
            ViewBag.id_hotel = id;
            return View();
        }
        [GridAction]
        public ActionResult SelectOrdenes(int id_hotel , int estado_orden)
        {
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra_estado(id_hotel , estado_orden )));
        }

        [GridAction]
        public ActionResult EliminarOrdenCompra(int id , int estado_orden) {
            int id_hotel = logica.retornar_orden(id).hotelID;
            logica.elimina_orden_compra(id);
            return View("IndexAdministracion", new GridModel(logica.retornar_ordenes_compra_estado( id_hotel, estado_orden )));
        }
        [GridAction]
        public ActionResult DetallesOrdenC( int id ) {
            return Json(new { msg = "ok" , orden_compra = logica.retornar_orden( id ) });
        }

        public ActionResult aceptarOrdenCompra(int id_oc) {
            string msg = "La orden " + id_oc+ " fue aceptada";
            try { logica.aceptar_orden_compra(id_oc); }
            catch (Exception e) { msg = e.Message; }

            return Json(new { msg = msg });
        }

        public ActionResult terminarOrdenCompra(int id_oc ) {
            string msg = "La orden "+ id_oc + " fue teminada de atender";
            try { logica.terminar_orden_compra(id_oc); }
            catch (Exception ex) { msg = ex.Message; }
            return Json(new { msg = msg });
        }

        public ActionResult cancelarOrdenCompra(int id_oc) {
            string msg = "La orden " + id_oc + " fue cancelada";
            try { logica.cancelar_orden_compra(id_oc); }
            catch (Exception ex) { msg = ex.Message;  }
            return Json(new { msg = msg });
        }

        public ActionResult pagarOrdenCompra(int id_oc)
        {
            string msg = "La orden " + id_oc + " fue pagada";
            //try { logica.pagar_orden_compra(id_oc); }
            //catch (Exception ex) { msg = ex.Message; }
            //return Json(new { msg = msg });
            ViewBag.id_oc = id_oc;
            ViewBag.oc = logica.retornar_orden(id_oc);
            return PartialView("ResumenOC");
        }
        public ActionResult registrarpagoOrdenCompra( int id_oc ,string nro_boleta) {
            string msg = "ok";
            try { logica.pagar_orden_compra(id_oc, nro_boleta); }
            catch (Exception e) { }
            return Json(new { msg = msg});
        }
        public JsonResult OrdenDeCompra (int id_oc)
        {
            OrdenCompraView p = logica.retornar_orden(id_oc);
            return Json(new { oc = p });
        }
        #endregion

        public ActionResult Reportes()
        {
            return View("ReporteCompras");
        }

        //public ActionResult Export()
        //{            

        //    //Create new Excel workbook
        //    var workbook = new HSSFWorkbook();

        //    //Create new Excel sheet
        //    var sheet = workbook.CreateSheet("Reporte de Compras");            

        //    //(Optional) set the width of the columns
        //    //sheet.SetColumnWidth(0, 10 * 256);
        //    //sheet.SetColumnWidth(1, 50 * 256);
        //    //sheet.SetColumnWidth(2, 50 * 256);
        //    //sheet.SetColumnWidth(3, 50 * 256);

        //    //Create a header row
        //    var headerRow = sheet.CreateRow(0);

        //    //Set the column names in the header row
        //    headerRow.CreateCell(0).SetCellValue("Orden de Compra ID");
        //    headerRow.CreateCell(1).SetCellValue("Hotel");
        //    headerRow.CreateCell(2).SetCellValue("Proveedor");
        //    headerRow.CreateCell(3).SetCellValue("Fecha Registro");
        //    headerRow.CreateCell(4).SetCellValue("Fecha Entrega Total");
        //    headerRow.CreateCell(5).SetCellValue("#Productos");
        //    headerRow.CreateCell(6).SetCellValue("Estado Orden");

        //    //(Optional) freeze the header row so it is not scrolled
        //    sheet.CreateFreezePane(0, 1, 0, 1);
          
            
        //    int max=logica.retornar_ordenes_compra().Count();
        //    if (max == 0)
        //        return Index();

        //    //Populate the sheet with values from the grid data
        //    for (int i=1; i<max; i++)
        //    {
        //        //Create a new row
        //        var row = sheet.CreateRow(i+1);

        //        //Set values for the cells
        //        row.CreateCell(0).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).ordenID);
        //        row.CreateCell(1).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).hotel);
        //        row.CreateCell(2).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).razon_proveedor);
        //        row.CreateCell(3).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).fecha_registro.ToString());
        //        row.CreateCell(4).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).fecha_llegada.ToString());
        //        row.CreateCell(5).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).nro_productos);
        //        row.CreateCell(6).SetCellValue(logica.retornar_ordenes_compra().ElementAt(i).estado_orden);
    
        //    }

        //    //Write the workbook to a memory stream
        //    MemoryStream output = new MemoryStream();
        //    workbook.Write(output);

        //    //Return the result to the end user

        //    return File(output.ToArray(),   //The binary data of the XLS file
        //        "application/vnd.ms-excel", //MIME type of Excel files
        //        "ReporteCompras.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
        //}
    }
}
