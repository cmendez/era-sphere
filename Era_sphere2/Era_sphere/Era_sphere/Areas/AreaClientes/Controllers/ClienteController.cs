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

            List<ReciboLinea> recibo_linea = new List<ReciboLinea>();
            if (id > 0)
            {
                Cliente cliente = cliente_logica.retornarCliente(id);
                if(cliente.recibos_cliente != null) foreach (Recibo r in cliente.recibos_cliente)
                    if(r.recibo_lineas != null) foreach (ReciboLinea rl in r.recibo_lineas)
                        if (rl.de_servicio)
                            recibo_linea.Add(rl);
                ViewBag.estado = cliente.estado.descripcion;
                ViewBag.puntos = cliente.puntos_cliente;
            }
            else
            {
                ViewBag.estado = "";
                ViewBag.puntos = "";
            }
            return View("DetalleClienteTemplate", recibo_linea);
        }

        [HttpPost]
        public ActionResult DameClientes(string text)
        {
            var clientes = cliente_logica.retornarClientesFiltro(text);
            return new JsonResult() { Data = clientes };
        }


    }
}
