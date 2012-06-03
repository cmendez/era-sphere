using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaEmpleados.Models;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleado;
using Era_sphere.Areas.AreaAsistenciaEmpleados.Models;

namespace Era_sphere.Areas.AreaEmpleados.Controllers
{
    public class AsistenciaEmpleadoController : Controller
    {
        LogicaAsistenciaEmpleado asistencia_logica = new LogicaAsistenciaEmpleado();

        public ActionResult Index()
        {
            return View("Index");
        }
        /*
        public ActionResult CrearEmpleado()
        {
            return View("CrearEmpleado");
        }
        */
        
        public ActionResult RegistrarAsistencia(int id)
        {
            AsistenciaEmpleado asistenciaEmpleado = new AsistenciaEmpleado();
            DateTime date = DateTime.Now; 

            asistenciaEmpleado.empleadoID = "";
            asistenciaEmpleado.asistencia = "Entrada";
            asistenciaEmpleado.fechaHoraEntrada = date;
            
            asistencia_logica.agregarAsistenciaEmpleado(asistenciaEmpleado);
            return View("Index");
        }
        
        public ActionResult RegistrarSalida(int id)
        {
            AsistenciaEmpleado asistenciaEmpleado = new AsistenciaEmpleado();
            DateTime date = DateTime.Now;

            asistenciaEmpleado.empleadoID = "";
            asistenciaEmpleado.asistencia = "Salida";
            asistenciaEmpleado.fechaHoraSalida = date;

            asistencia_logica.agregarAsistenciaEmpleado(asistenciaEmpleado);
            return View("Index");
        }

    }
}
