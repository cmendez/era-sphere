using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;



namespace Era_sphere.Areas.ApiCliente.Controllers
{
    public class ClienteController : Controller
    {
        LogicaCliente cliente_logica = new LogicaCliente();

        [HttpGet]
        public JsonResult ClientesListaGeneral()
        {
            Cliente c = new Cliente();
            c.clienteID = 1;
            c.nombre = "churrepom";
            c.apellido_paterno = "churreta";
            cliente_logica.agregarClientes(c);
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
                        this.cliente_logica.agregarClientes(cliente);
                        return Json(new {Error =false,Mensaje = "Success"}, JsonRequestBehavior.AllowGet);
                    case "PUT":
                        this.cliente_logica.modificarCliente(cliente);
                        return Json(new { Error = false, Mensaje = "Success" }, JsonRequestBehavior.AllowGet);
                    case "DELETE":
                        this.cliente_logica.eliminarCliente(cliente.clienteID);
                        return Json(new { Error = false, Mensaje = "Success" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) { return Json(new { Error = true, Message = "error en backend" }); }
            return Json(new { Error = true, Message = "Operacion no soportada " }, JsonRequestBehavior.AllowGet);
        }

    }
}
