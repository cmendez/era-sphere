using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;
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
            ViewData["es_partial"] = false;
            return View("IndexCliente");
        }

        [HttpPost]
        public JsonResult LoginResult(string user, string password)
        {
            Cliente cliente = cliente_logica.context.clientes.FirstOrDefault(x => x.usuario == user && x.password == x.password);
            if (cliente == null) return Json(new { ok = false, error = "El usuario o password no es el correcto" });

            return Json(new { ok = true, cliente_id = cliente.ID, tipo_id = cliente.tipoID, mensaje = "wiiii", 
                                nombre = cliente.nombre + " " + cliente.apellido_materno + " " + cliente.apellido_paterno});
        }

        public ActionResult IndexPartial()
        {
            ViewData["es_partial"] = true;
            return PartialView("IndexCliente");
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

   
        //MODALES DE JURUDICO
        public JsonResult MostrarJuridicoEvento(int id)
        {
            return Json(new { id = id });
        }

        public ActionResult ClienteJuridicoShow(int id)
        {
            ClienteJuridicoView cliente = new ClienteJuridicoView(cliente_logica.retornarCliente(id));
            return PartialView("ClienteJuridicoShowTemplate", cliente);
        }

        //MODALES DE NATURAL

        public JsonResult MostrarNaturalEvento(int id)
        {
            return Json(new { id = id });
        }

        public ActionResult ClienteNaturalShow(int id)
        {
            ClienteNaturalView cliente = new ClienteNaturalView(cliente_logica.retornarCliente(id));
            return PartialView("ClienteNaturalShowTemplate", cliente);
        }



        //public ActionResult ClienteNaturalShow()
        //{
        //    return View("ClienteNaturalShowTemplate");
        //}

        //DETALLE DEL CLIENTE
        public ActionResult DetalleCliente(int id)
        {
            List<ReciboLinea> lineas = new List<ReciboLinea>();
            List<int> recibos = cliente_logica.context.recibos.Where(x => x.clienteID == id).ToList().Select(y => y.ID).ToList();
            lineas = cliente_logica.context.recibos_lineas.Where(x => recibos.Contains(x.reciboID.Value)).ToList();
            
            Cliente cliente = cliente_logica.retornarCliente(id);
            
            if (id > 0)
            {
          
                ViewBag.estado = cliente.estado.descripcion;
                ViewBag.puntos = cliente.puntos_cliente;
            }
            else
            {
                ViewBag.estado = "";
                ViewBag.puntos = "";
            }
            return View("DetalleClienteTemplate", lineas);
        }

        [HttpPost]
        public ActionResult DameClientes(string text)
        {
            var clientes = cliente_logica.retornarClientesFiltro(text);
            return new JsonResult() { Data = clientes };
        }

        [HttpPost]
        public ActionResult DameClientesNatural(string text)
        {
            var clientes = cliente_logica.retornarClientesNaturalFiltro(text);
            return new JsonResult() { Data = clientes };
        }


        public int ValidaClientes(int id_tipo_documento, string documento, string tarjeta_cliente)
        {

            var clientes = cliente_logica.retornarClientes().Where(c => ((c.tipo_documentoID == id_tipo_documento) && (c.documento_identidad == documento)) ||(c.tarjeta_cliente== tarjeta_cliente));
            if (clientes.Count() == 0)
                return 0;
            else
                return 1;
        }

        public int ValidaClientesJuridicos(string ruc, string tarjeta_cliente)
        {

            var clientes = cliente_logica.retornarClientes().Where(c => (c.ruc == ruc) || (c.tarjeta_cliente == tarjeta_cliente));
            if (clientes.Count() == 0)
                return 0;
            else
                return 1;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ObtieneDatosCliente(string cliente_raw)
        {
            int clienteId = cliente_logica.toCliente(cliente_raw);
            return Json(new { id = clienteId });
        }

    }
}
