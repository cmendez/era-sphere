using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaCliente.Models;

namespace Era_sphere.Areas.AreaCliente.Controllers
{
    public class ClienteController : Controller
    {
        LogicaCliente cliente_logica = new LogicaCliente();

        [HttpGet]
        public JsonResult ClientesListaGeneral()
        {
            return Json(cliente_logica.retornarClientes(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ClientesListaQuery(Cliente cliente)
        {
            return Json(cliente_logica.buscarCliente(cliente), JsonRequestBehavior.AllowGet);
        }
        [RestHttpVerbFilter]
        public JsonResult Clientes(int? id, Cliente cliente, string http_verb)
        {
            try
            {
                switch (http_verb)
                {
                    case "POST":
                        this.cliente_logica.agregarCliente(cliente);
                        return Json(new {Error =false,Mensaje = "Success"}, JsonRequestBehavior.AllowGet);
                    case "PUT":
                        this.cliente_logica.modificarCliente(cliente);
                        return Json(new { Error = false, Mensaje = "Success" }, JsonRequestBehavior.AllowGet);
                    case "DELETE":
                        this.cliente_logica.eliminarCliente(cliente.ID);
                        return Json(new { Error = false, Mensaje = "Success" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex ) { return Json(new { Error = true, Message = ex.Data }); }
            return Json(new { Error = true, Message = "Operacion no soportada" }, JsonRequestBehavior.AllowGet);
        }

    }
}
