using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_App.Models;
using Test_App.Areas.ApiCliente.Models;

namespace Test_App.Areas.ApiCliente.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /ApiCliente/Cliente/
        IClientManager client_manager = new IEClienteController();
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string test() { return "this is a test"; }
        [HttpGet]
        public String test_fun()
        {
            return "this is a test";
        }
        [HttpGet]
        public JsonResult ClientesLista()
        {

            return Json(client_manager.retornar_clientes(),JsonRequestBehavior.AllowGet);
        }
        [RestHttpVerbFilter]
        public JsonResult Clientes(int? id, Cliente cliente, string http_verb)
        {
            try
            {
                switch (http_verb)
                {
                    case "POST":
                        return Json(this.client_manager.agregar_cliente(cliente),JsonRequestBehavior.AllowGet);
                    case "PUT":
                        return Json(this.client_manager.modificar_cliente(cliente),JsonRequestBehavior.AllowGet);
                    case "DELETE":
                        return Json(this.client_manager.eliminar_cliente(cliente),JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) { return Json(new { Error = true, Message = "error en backend" }); }
            return Json(new { Error = true, Message = "Operacion no soportada " },JsonRequestBehavior.AllowGet);
        }

    }
}
