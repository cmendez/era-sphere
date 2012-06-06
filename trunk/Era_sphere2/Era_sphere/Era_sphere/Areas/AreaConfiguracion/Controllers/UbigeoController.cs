using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class UbigeoController : Controller
    {
        //
        // GET: /AreaConfiguracion/Ubigeo/
        /* Ubigeo Controller para lo que se quiera */

        LogicaUbigeo logica_ubigeo = new LogicaUbigeo();

        [HttpPost]
        public ActionResult DamePaises(String pais)
        {
            var paises = logica_ubigeo.retornarPaisesFiltro(pais);
            return new JsonResult() { Data = paises };
        }
    }
}
