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
        public ActionResult Select()
        {
            //ViewBag.perfiles = perfil_logica.retornarPerfiles();
            ViewBag.empleado = le.retornarEmpleados();
            return View("Index", new GridModel(le.retornarEmpleados()));
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

        /*String nombreCargo, String estado, String cad_horario, String cad_horasIn,
                                    String cad_horasOut, String sueld*/


        public JsonResult newEmpleado(EmpleadoView ev) {
            Empleado e = ev.deserializa(le);
            Empleado empleado = new Empleado()
            {
                nombre_cargo = ev.nombre_cargo,
                estado = ev.estado,
                cad_horario = ev.cad_horario,
                cad_horasIn = ev.cad_horasIn,
                cad_horasOut = ev.cad_horasOut,
                sueldo = ev.sueldo,

                //Persona
                nombre = ev.nombre,
                apellido_materno = ev.apellido_materno,
                apellido_paterno = ev.apellido_paterno,
                direccion = ev.direccion,
                celular = ev.celular,
                telefono = ev.telefono,
              
                ciudadID = 1,
                paisID = 1,
                tipoID = 1
            };
            
            //le.agregarEmpleado(e);
            return Json(new { me = "" });
        }

        [HttpPost]
        public JsonResult nuevoEmpleado(String nombreCargo, String estado, String cad_horario, String cad_horasIn,
                                    String cad_horasOut, String sueldo)
        {
            
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
             
            le.agregarEmpleado(empleado);   
            //perfil_empleado.agregarEmpleado(empleado);
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
