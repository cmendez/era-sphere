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
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipoID == tipoi)));
        
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int tipoi)
        {
            ClienteView cliente_view = new ClienteView();
            cliente_view.nombre = "-";
            cliente_view.apellido_materno = "-";
            cliente_view.apellido_paterno = "-";
            cliente_view.documento_identidad = "-";
            cliente_view.razon_social = "-";
            cliente_view.ruc = "-";
            if (TryUpdateModel(cliente_view))
            {
                cliente_view.tipoID = tipoi;
                cliente_logica.agregarCliente(cliente_view);
            }
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipoID == tipoi)));
        }

        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id, int tipoi)
        {
            int cliente_id = id ?? -1;
            cliente_logica.eliminarCliente(cliente_id);
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipoID == tipoi)));
    
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(ClienteView cliente, int tipoi)
        {
            cliente_logica.modificarCliente(cliente);
            return View("IndexCliente", new GridModel(cliente_logica.retornarClientes().Where(c => c.tipoID == tipoi)));
            // return RedirectToAction("proveedor");
        }



    }
}
