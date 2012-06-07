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

        [GridAction]
        public ActionResult AddEmpleado(Empleado empleado)
        {
            perfil_empleado.agregarEmpleado(empleado);
            return View("Index", new GridModel(perfil_empleado.retornarEmpleados()));
        }

        [GridAction]
        public ActionResult Delete(int id)
        {
            perfil_empleado.eliminarEmpleado(id);
            return View("IndexCliente", new GridModel(perfil_empleado.retornarEmpleados()));
        }

        /*String nombreCargo, String estado, String cad_horario, String cad_horasIn,
                                    String cad_horasOut, String sueld*/

        [HttpPost]
        public JsonResult nuevoEmpleado(EmpleadoView empleado)
        {
            /*
            Empleado empleado = new Empleado()
            {
                nombre_cargo = nombreCargo,
                estado = estado,
                cad_horario = cad_horario,
                cad_horasIn = cad_horasIn,
                cad_horasOut = cad_horasOut,
                sueldo = sueldo,
                //Persona
                ciudadID = 1,
                paisID = 1,
                tipoID = 1
            };
             */
            //perfil_empleado.agregarEmpleado(empleado);   
            perfil_empleado.agregarEmpleado(empleado);
         return Json(new { me = "" });
        }
        /*
        ActionResult nuevoEmpleado(String nombreCargo, String estado, String cad_horario, String cad_horasIn,
                                    String cad_horasOut, String sueldo) {

         Empleado empleado = new Empleado(nombreCargo, estado, cad_horario, cad_horario, cad_horasOut, sueldo);
         perfil_empleado.agregarEmpleado(empleado);
         return View("Index", new GridModel(perfil_empleado.retornarEmpleados()));
        } 
         * */
    }
}
