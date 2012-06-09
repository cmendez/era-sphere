using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados;

namespace Era_sphere.Areas.AreaEmpleados.Controllers
{
    public class AsistenciaEmpleadoController : Controller
    {
        LogicaAsistenciaEmpleado asistencia_logica = new LogicaAsistenciaEmpleado();

        public ActionResult Index()
        {
            return View("Index");
        }
       
        [HttpPost]
        public JsonResult RegistrarAsistencia(int iduser)
        {
            bool yaRegistro;
            DateTime date = DateTime.Now;

            yaRegistro = asistencia_logica.validarRegistro(iduser, date, 1);

            if (!yaRegistro)
            {
                AsistenciaEmpleado asistenciaEmpleado = new AsistenciaEmpleado();
              
                asistenciaEmpleado.empleadoID = iduser.ToString();
                asistenciaEmpleado.s_asistencia = "ENTRADA";
                asistenciaEmpleado.fechaHoraEntrada = date;
                asistencia_logica.agregarAsistenciaEmpleado(asistenciaEmpleado);
                return Json(new { me = "" });
            }
            else
                return Json(new { me = "Ya ha registrado una entrada anteriormente." });
   
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            ViewBag.asistencias = asistencia_logica.retornarAsistencias(id);
            return View("Index", new GridModel(asistencia_logica.retornarAsistencias(id)));
        }
        
        [HttpPost]
        public JsonResult RegistrarSalida(int iduser)
        {
            bool yaRegistro, existeEntrada;
            DateTime date = DateTime.Now;

            existeEntrada = asistencia_logica.existeEntrada(iduser, date);

            if (!existeEntrada)
            {
                return Json(new { me = "No puede registrar salida sin haber registrado una entrada" });
            }
            else
            {
                yaRegistro = asistencia_logica.validarRegistro(iduser, date, 2);

                if (!yaRegistro)
                {
                    
                    asistencia_logica.modificarAsistenciaEmpleado(iduser, date);
                    return Json(new { me = "" });
                }
                else
                {
                    return Json(new { me = "Ya ha registrado su salida" });
                }
            }
        }

    }
}
