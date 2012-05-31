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
            return View("IndexCliente");
        }

        [GridAction]
        public ActionResult SelectNatural()
        {
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesNaturales()));
        
        }
        [GridAction]
        public ActionResult SelectJuridico()
        {
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesJuridicos()));

        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertNatural()
        {
            ClienteNaturalView cliente_view = new ClienteNaturalView();
            if (TryUpdateModel(cliente_view))
            {
                cliente_logica.agregarCliente(cliente_view.deserializa(this.cliente_logica));
            }
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesNaturales()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertJuridico()
        {
            ClienteJuridicoView cliente_view = new ClienteJuridicoView();
            if (TryUpdateModel(cliente_view))
            {
                cliente_logica.agregarCliente(cliente_view.deserializa(this.cliente_logica));
            }
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesJuridicos()));
        }

        
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteNatural(int? id)
        {
            int cliente_id = id ?? -1;
            cliente_logica.eliminarCliente(cliente_id);
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesNaturales()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteJuridico(int? id)
        {
            int cliente_id = id ?? -1;
            cliente_logica.eliminarCliente(cliente_id);
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesJuridicos()));
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateNatural(ClienteNaturalView cliente)
        {
            cliente_logica.modificarCliente(cliente.deserializa(cliente_logica));
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesNaturales()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateJuridico(ClienteJuridicoView cliente)
        {
            cliente_logica.modificarCliente(cliente.deserializa(cliente_logica));
            return View("IndexCliente", new GridModel(cliente_logica.retonarClientesJuridicos()));
        }

   
        public JsonResult MostrarJuridico(int id)
        {
            var cliente = cliente_logica.retornarCliente(id);
            var cliente_view = new ClienteJuridicoView(cliente);
            string pais = cliente.pais.nombre;
            string estado = cliente.estado.descripcion;
            string ciudad = cliente.ciudad.nombre;
            return Json(new { cliente = cliente_view, estado = estado, pais = pais, ciudad = ciudad }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClienteJuridicoShow()
        {
            return View("ClienteJuridicoShowTemplate");
        }
    }
}
