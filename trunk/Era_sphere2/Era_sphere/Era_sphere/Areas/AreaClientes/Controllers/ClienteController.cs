using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Generics;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaClientes.Controllers
{
    public class ClienteController : Controller
    {
        LogicaCliente cliente_logica = new LogicaCliente();

        public ActionResult Index()
        {
            ViewBag.clientes = cliente_logica.retornarClientes();
            return View("IndexCliente");
        }

        [GridAction]
        public ActionResult Select(int tipoi)
        {
            Cliente.TipoPersona tipo = tipoi == 0 ? Cliente.TipoPersona.natural : Cliente.TipoPersona.juridico;
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipo == tipo)));
        
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int tipoi)
        {
            Cliente.TipoPersona tipo = tipoi == 0 ? Cliente.TipoPersona.natural : Cliente.TipoPersona.juridico;
            ClienteView cliente_view = new ClienteView();
            if (TryUpdateModel(cliente_view))
            {
                cliente_view.tipo = tipo;
                cliente_logica.agregarCliente(cliente_view);
            }
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c=>c.tipo == tipo)));
        }

        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id, int tipoi)
        {
            Cliente.TipoPersona tipo = tipoi == 0 ? Cliente.TipoPersona.natural : Cliente.TipoPersona.juridico;
            int cliente_id = id ?? -1;
            cliente_logica.eliminarCliente(cliente_id);
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c =>c.tipo == tipo)));
    
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ClienteView cliente, int tipoi)
        {
            Cliente.TipoPersona tipo = tipoi == 0 ? Cliente.TipoPersona.natural : Cliente.TipoPersona.juridico;
            cliente_logica.modificarCliente(cliente);
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipo == tipo)));
            // return RedirectToAction("proveedor");
        }



    }
}
