using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaClientes.Controllers
{
    public class ClienteController : Controller
    {
        LogicaCliente cliente_logica = new LogicaCliente();

        public ActionResult Index(Cliente cliente_busqueda)
        {
            ViewBag.clientes = cliente_logica.retornarClientes();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            cliente.tipo = Cliente.TipoPersona.natural;
            cliente_logica.agregarCliente(cliente);
            return RedirectToAction("Index");
        }
        public ActionResult Delete() {
            return View();
        }
        public ActionResult Detail() {
            return View();
        }
    }
}
