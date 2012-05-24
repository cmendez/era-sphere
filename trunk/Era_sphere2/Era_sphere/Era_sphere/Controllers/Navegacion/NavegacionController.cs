using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;

namespace Era_sphere.Controllers.Navegacion
{
    public class NavegacionController : Controller
    {
        //
        // GET: /Navegacion/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListaMenu(String token)
        {
            var menu = new NavegacionModel().getMenu(token);
            return new JsonResult() { Data = menu };
        }

    }
}
