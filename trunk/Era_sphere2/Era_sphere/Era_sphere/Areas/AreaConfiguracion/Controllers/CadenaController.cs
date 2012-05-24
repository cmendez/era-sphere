using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaConfiguracion.Models;
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
//validar que solo se pueda crear una cadena
            List<Cadena> lista = cadena_logica.retornarCadenas();
            if (lista.Count > 1)
            {
                Response.Write("<script>alert('Errorrrrrrr')</script>"); //este de aca no se muestra T_T
                return RedirectToAction("Index");
            }
            return View(); //devuelve el view de cadena, CREATE.CSHTML
        }
        [HttpPost]
        public ActionResult Create(Cadena cadena)
        {
            //cadena.asdasd = Cadena.TipoPersona.natural;
            if (ModelState.IsValid)
            {
                cadena_logica.agregarCadena(cadena);
                return RedirectToAction("Index"); //regresa al index de cadena
            }
            return View();
        }

        public ActionResult Edit(int id=0)
        {
            List<Cadena> lista = cadena_logica.retornarCadenas();
            id = lista[lista.Count - 1].ID;
            return View("Edit", cadena_logica.retornarCadena(id));
        }

        [HttpPost]
        public ActionResult Edit(Cadena cadena)
        {
            try
            { 
                cadena_logica.modificarCadena(cadena);
            }
            catch
            { }
            return RedirectToAction("Index");
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
        public ActionResult Details(int id=0)
        {
            try
            {
                List<Cadena> lista = cadena_logica.retornarCadenas();
                id = lista[lista.Count - 1].ID;
                return View("Details", cadena_logica.retornarCadena(id));
            }
            catch{
                return RedirectToAction("Index");
            }
        }

    }
}
