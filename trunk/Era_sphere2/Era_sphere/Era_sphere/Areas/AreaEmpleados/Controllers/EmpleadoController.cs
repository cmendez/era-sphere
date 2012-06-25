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
        LogicaEmpleado le = new LogicaEmpleado();

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CrearEmpleado()
        {
            return View("CrearEmpleado");
        }

        [GridAction]
        public JsonResult DameEmpleado(int empleadoID)
        {
            var empleado = le.retornarEmpleado(empleadoID);
            return new JsonResult() { Data = empleado };
        }
        
        [HttpPost]
        public JsonResult ActualizarEmpleado(EmpleadoView emp)
        {
            Empleado empleado = emp.deserializa(le);
            le.modificarEmpleado(empleado);
            return Json(new { me = "" });
        }
        

        [GridAction]
        public ActionResult Select()
        {
            return View("Index", new GridModel(le.retornarEmpleados()));
        }

        [HttpPost]
        public JsonResult LoginResult(String user, String password)
        {
            var empleados = le.loginEmpleado(user, password);
            return new JsonResult() { Data = empleados };
        }



        [GridAction]
        public ActionResult AddEmpleado(Empleado empleado)
        {
            le.agregarEmpleado(empleado);
            return View("Index", new GridModel(le.retornarEmpleados()));
        }

        [GridAction]
        public ActionResult Delete(int id)
        {
            le.eliminarEmpleado(id);
            return View("IndexCliente", new GridModel(le.retornarEmpleados()));
        }

        [HttpPost]
        public JsonResult nuevoEmpleado(EmpleadoView emp)
        {
            Empleado empleado =  emp.deserializa(le);
            le.agregarEmpleado(empleado);   
         return Json(new { me = "" });
        }
       
    }
}
