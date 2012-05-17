using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.TipoTemporada;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TiposTemporadaController : Controller
    {
        //
        // GET: /AreaConfiguracion/TiposTemporada/

        InterfazLogicaTipoTemporada tipotemporada_logica = new LogicaTipoTemporada();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tipostemporada()
        {
            ViewBag.tipostemporada = tipotemporada_logica.retornarTiposTemporada();
            return View("Index", tipotemporada_logica.retornarTiposTemporada());
            //ViewBag.proveedores = proveedor_logica.retornarProveedores();
            //return View("Index", proveedor_logica.retornarProveedores());
        }


        [GridAction]
        public ActionResult Select()
        {
            ViewBag.tipostemporada = tipotemporada_logica.retornarTiposTemporada();
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {
            //Console.WriteLine("Llega");
            TipoTemporada tipotemporada = new TipoTemporada();
            if (TryUpdateModel(tipotemporada))
            {
                tipotemporada_logica.agregarTipoTemporada(tipotemporada);

            }
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            int _tipotemporada_id = id ?? -1;
            tipotemporada_logica.eliminarTipoTemporada(_tipotemporada_id);
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(TipoTemporada c)
        {

            tipotemporada_logica.modificarTipoTemporada(c);
            return View("Index", new GridModel(tipotemporada_logica.retornarTiposTemporada()));
        }


    }
}
