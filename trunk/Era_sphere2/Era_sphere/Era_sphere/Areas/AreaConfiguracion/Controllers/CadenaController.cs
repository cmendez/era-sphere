using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.Configuracion.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class CadenaController : Controller
    {
        LogicaCadena cadena_logica = new LogicaCadena();

        public ActionResult Index(Cadena cliente_busqueda)
        {
            ViewBag.cadenas = cadena_logica.retornarCadenas();
            return View();
        }

        public ActionResult Create()
        {
            //var vals = Enum.GetValues(typeof(Cliente.EstadoCliente));
            var con = new UbigeoContext();
            //con.Seed();
            ViewBag.paises = (new UbigeoContext()).paises.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cadena cadena)
        {
            //cadena.asdasd = Cadena.TipoPersona.natural;
            cadena_logica.agregarCadena(cadena);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", cadena_logica.retornarCadena(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            cadena_logica.eliminarCadena(id);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(cadena_logica.retornarCadena(id));
        }
        public ActionResult Detail(int id)
        {
            return View("Details", cadena_logica.retornarCadena(id));
        }

    }
}
