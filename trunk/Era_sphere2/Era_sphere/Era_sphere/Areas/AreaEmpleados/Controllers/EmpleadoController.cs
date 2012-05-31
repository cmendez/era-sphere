using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaEmpleados.Models;

namespace Era_sphere.Areas.AreaEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        LogicaEmpleado perfil_empleado = new LogicaEmpleado();

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CrearEmpleado() 
        {
            return View("CrearEmpleado");
        }


        [GridAction]
        public ActionResult Select()
        {
            //ViewBag.perfiles = perfil_logica.retornarPerfiles();
            ViewBag.empleado = perfil_empleado.retornarEmpleados();
            return View("Index", new GridModel(perfil_empleado.retornarEmpleados()));
        }

    }
}
