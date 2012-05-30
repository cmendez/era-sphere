using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Era_sphere.Areas.AreaEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /AreaEmpleados/Empleado/

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CrearEmpleado() 
        {
            return View("CrearEmpleado");
        }

    }
}
