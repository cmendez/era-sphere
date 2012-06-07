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
        /*
        public ActionResult CrearEmpleado()
        {
            return View("CrearEmpleado");
        }
        */
        
        public ActionResult RegistrarAsistencia(int id)
        {
            bool yaRegistro;
            DateTime date = DateTime.Now;

            yaRegistro = asistencia_logica.validarRegistro(id, date, 1);

            if (!yaRegistro)
            {
                AsistenciaEmpleado asistenciaEmpleado = new AsistenciaEmpleado();
              
                asistenciaEmpleado.empleadoID = id.ToString();
                asistenciaEmpleado.s_asistencia = "ENTRADA";
                asistenciaEmpleado.fechaHoraEntrada = date;
                //asistenciaEmpleado.fechaHoraSalida = null;

                asistencia_logica.agregarAsistenciaEmpleado(asistenciaEmpleado);
                //return View("Index");
                return RedirectToAction("Index");
            }
            else
            {
                //Response.Write("<script>alert('Ya habia registrado su salida')</script>");
                //return View("Index");
                return RedirectToAction("Index");
            }
            
            
        }

        [GridAction]
        public ActionResult Select(int id)
        {
            ViewBag.asistencias = asistencia_logica.retornarAsistencias(id);
            return View("Index", new GridModel(asistencia_logica.retornarAsistencias(id)));
        }
        
        public ActionResult RegistrarSalida(int id)
        {
            bool yaRegistro, existeEntrada;
            DateTime date = DateTime.Now;

            existeEntrada = asistencia_logica.existeEntrada(id, date);

            if (!existeEntrada)
            {
                Response.Write("<script>alert('No puede registrar salida sin haber registrado una entrada')</script>");
                return RedirectToAction("Index");
                //return View("Index");
            }
            else
            {
                yaRegistro = asistencia_logica.validarRegistro(id, date, 2);

                if (!yaRegistro)
                {
                    //AsistenciaEmpleado asistenciaEmpleado = new AsistenciaEmpleado();

                    //asistenciaEmpleado.empleadoID = id.ToString();
                    //asistenciaEmpleado.asistencia = "Salida";
                    //asistenciaEmpleado.fechaHoraSalida = date;

                    //asistencia_logica.agregarAsistenciaEmpleado(asistenciaEmpleado);

                    asistencia_logica.modificarAsistenciaEmpleado(id, date);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Response.Write("<script>alert('Ya habia registrado su salida')</script>");
                    //return View("Index");
                    return RedirectToAction("Index");
                }
            }
        }

    }
}
