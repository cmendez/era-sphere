using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class PerfilesController : Controller
    {
        LogicaPerfil perfil_logica = new LogicaPerfil();

        public ActionResult Index(Perfil cliente_busqueda)
        {
            //ViewBag.cadenas = perfil_logica.retornarCadenas();
            return View();
        }

        [GridAction]
        public ActionResult Select()
        {
            ViewBag.perfiles = perfil_logica.retornarPerfiles();
            return View("Index", new GridModel(perfil_logica.retornarPerfiles()));
        }

        [GridAction]
        public ActionResult DamePerfil(int perfilID) {

            var perfil = perfil_logica.retornarPerfil(perfilID);
            return new JsonResult() { Data = perfil };
        }

       
        [GridAction]
        public ActionResult Update(Perfil perfil)
        {
            perfil_logica.modificarPerfil(perfil);
            return View("Index", new GridModel(perfil_logica.retornarPerfiles()));
        }

        [GridAction]
        public ActionResult Delete(int id)
        {
            perfil_logica.eliminarPerfil(id);
            return View("Index", new GridModel(perfil_logica.retornarPerfiles()));
        }


        [HttpPost]
        public JsonResult nuevoPerfil(String nombre, String descripcion, String lista )
        {
            Perfil perfil = new Perfil(){
                nombrePerfil = nombre,
                descripcion = descripcion,
                listaVisibilidad = lista
            };

            if (TryUpdateModel(perfil))
            {
                perfil_logica.agregarPerfil(perfil);
                return Json(new { me = "" });
            }
            else return Json(new { me = "error" });
        }
    }
}
