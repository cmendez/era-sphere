using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class ComodidadesController : Controller
    {
        //
        // GET: /AreaConfiguracion/Comodidades/

        InterfazLogicaComodidades comodidades_logica = new LogicaComodidades();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult comodidades()
        {
            ViewBag.comodidades = comodidades_logica.retornarComodidades();
            return View( "Index", comodidades_logica.retornarComodidades() );
            //ViewBag.proveedores = proveedor_logica.retornarProveedores();
            //return View("Index", proveedor_logica.retornarProveedores());
        }


        [GridAction]
        public ActionResult Select()
        {
            ViewBag.proveedores = comodidades_logica.retornarComodidades();
            return View("Index", new GridModel(comodidades_logica.retornarComodidades()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {
            Console.WriteLine("Llega");
            Comodidad comodidad = new Comodidad();
            if (TryUpdateModel(comodidad))
            {
                comodidades_logica.agregarComodidad(comodidad);

            }
            return View("Index", new GridModel(comodidades_logica.retornarComodidades()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int _comodidad_id = id ?? -1;
            comodidades_logica.eliminarComodidad(_comodidad_id);
            return View("Index", new GridModel(comodidades_logica.retornarComodidades()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(Comodidad c)
        {

            comodidades_logica.modificarComodidad( c );
            return View("Index", new GridModel(comodidades_logica.retornarComodidades()));
        }



    }
}
