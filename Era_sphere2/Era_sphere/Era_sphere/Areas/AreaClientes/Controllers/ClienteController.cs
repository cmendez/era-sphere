using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Generics;

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
            //var vals = Enum.GetValues(typeof(Cliente.EstadoCliente));
            //var con = new UbigeoContext();
            //con.Seed();
            List<Pais> paises = (new EraSphereContext()).paises.ToList();
            ViewBag.paises = paises;
            return View();
        }
        
        /*[HttpPost]
        public ActionResult Create(ClienteView cliente)
        {
            Cliente nuevo = new Cliente
            //cliente.paisID = (new EraSphereContext()).paises.Find(cliente.paisID);
            //cliente_logica.agregarCliente(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           cliente_logica.eliminarCliente(id);
           return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id) {
            return View(cliente_logica.retornarCliente(id));
        }

        public ActionResult Detail(int id) {
            return View( "Detail_natural",cliente_logica.retornarCliente(id));
        }*/
    }
}
