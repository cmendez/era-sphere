using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReportes.Models.ReporteEmpleados;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados;

namespace Era_sphere.Areas.AreaReportes.Controllers
{
    public class ReporteEmpleadoController : Controller
    {
        public ActionResult Index(/*FormReporteEmpleado formReporte*/)
        {
            return View("IndexFormReporteEmpleado");
        }

        [HttpPost]
        public ActionResult Generar(FormReporteEmpleado formReporte)
        {
            int x = 10;

            ReporteEmpleado reporte = new ReporteEmpleado();
            List<Empleado> listaEmpleados = (new EraSphereContext()).empleados.ToList();
            List<Empleado> listaEmpleadosFiltrada = new List<Empleado>();
            List<AsistenciaEmpleado> listaAsistencias = (new EraSphereContext()).asistenciaEmpleado.ToList();
            List<AsistenciaEmpleado> listaAsistenciasFiltrada = new List<AsistenciaEmpleado>();
            List<ObjetoReporteEmpleado> listaFinal = new List<ObjetoReporteEmpleado>();

            reporte.cabecera = new String[2, 4]
                {
                    {"Codigo","Nombre Completo","Fecha","Asistencia"},
                    {"","","",""}
                 
                };

            //   {x.ToString(),s,y.ToString(),"fin XD"}

            reporte.fileName = "reporteEmpleados.xls";
            reporte.contenido = new String[100][];

            for (int i = 0; i < 100; i++)
                reporte.contenido[i] = new String[20];
            //mySpreadsheet.contenido[1] = new String[20];
            //mySpreadsheet.contenido[2] = new String[20];

            //USAR DATOS DEL FORMULARIO PARA SABER QUE QUIERE EL USUARIO EN SU REPORTE

            //listaEmpleados.Where(e => e.nombre.Contains(formReporte.nombre));
            //probar cuando ya pueda registrar varios empleados, y sino no funciona bien, usar listaEmpleadosFiltrada
            if (formReporte.nombre != null)           
            {
                foreach (Empleado empl in listaEmpleados)
                {
                    try
                    {
                        if (empl.nombre.Contains(formReporte.nombre))
                            listaEmpleadosFiltrada.Add(empl);
                    }
                    catch { }
                }
            }

            if (formReporte.apePaterno != null)
            {
                foreach (Empleado empl in listaEmpleados)
                {
                    try
                    {
                        if ((empl.apellido_paterno.Contains(formReporte.apePaterno)) && (!listaEmpleadosFiltrada.Contains(empl)))
                            listaEmpleadosFiltrada.Add(empl);
                    }
                    catch 
                    { }
                }
            }

            if (formReporte.apeMaterno != null)
            {
                foreach (Empleado empl in listaEmpleados)
                {
                    try
                    {
                        if ((empl.apellido_materno.Contains(formReporte.apeMaterno)) && (!listaEmpleadosFiltrada.Contains(empl)))
                            listaEmpleadosFiltrada.Add(empl);
                    }
                    catch { }
                }
            }

            /*if (formReporte.apePaterno != null)
                listaEmpleados.Where(e => e.apellido_paterno.Contains(formReporte.apePaterno));

            if (formReporte.apeMaterno != null)
                listaEmpleados.Where(e => e.apellido_materno.Contains(formReporte.apeMaterno));*/

            //formReporte.fechaInicio.AddMinutes(43);

            //try catch
            try
            {
                if (formReporte.fechaInicio.ToString() != "01/01/0001 12:00:00 a.m.")
                {
                    string f1 = formReporte.fechaInicio.ToShortDateString();
                                        
                    if (listaAsistencias[0].fechaHoraEntrada.ToString().CompareTo(formReporte.fechaInicio.ToString()) > 0)
                    { bool b = true; };
                    if (listaAsistencias[0].fechaHoraEntrada.ToString().CompareTo(formReporte.fechaInicio.ToString()) < 0)
                    { bool b = false; };
                    if (listaAsistencias[0].fechaHoraEntrada.Value.ToShortDateString() == f1)
                    { bool b = false; };

                    

                    foreach (AsistenciaEmpleado asisEmp in listaAsistencias)
                    {
                        if ((asisEmp.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaInicio.ToString()) > 0) ||                                         (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f1))
                                listaAsistenciasFiltrada.Add(asisEmp);
                    }
                    
                   /* listaAsistencias.Where(a => (a.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaInicio.ToString()) > 0) ||                                                (a.fechaHoraEntrada.Value.ToShortDateString() == f1));*/

                }

                if (formReporte.fechaFin.ToString() != "01/01/0001 12:00:00 a.m.")
                {
                    string f2 = formReporte.fechaFin.ToShortDateString();

                    foreach (AsistenciaEmpleado asisEmp in listaAsistencias)
                    {
                        if ((asisEmp.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaFin.ToString()) < 0) ||                                          (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f2))
                            if (!listaAsistenciasFiltrada.Contains(asisEmp))
                                listaAsistenciasFiltrada.Add(asisEmp);
                    }

                /*    listaAsistencias.Where(a => (a.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaFin.ToString()) < 0) ||                                                   (a.fechaHoraEntrada.Value.ToShortDateString() == f2)); */
                }
                ObjetoReporteEmpleado objReporteEmp;
                
                foreach (AsistenciaEmpleado asistencia in listaAsistenciasFiltrada)
                {
                    foreach (Empleado empleados in listaEmpleadosFiltrada)
                    {
                        if (Int32.Parse(asistencia.empleadoID) == empleados.ID)
                        {
                            objReporteEmp = new ObjetoReporteEmpleado();
                            objReporteEmp.empleadoID = empleados.ID.ToString();
                            objReporteEmp.nombreCompleto = empleados.nombre + " " + empleados.apellido_paterno + " " +                                                                         empleados.apellido_materno;
                            objReporteEmp.fecha = asistencia.fechaHoraEntrada;
                            objReporteEmp.asistencia = asistencia.s_asistencia;
                            listaFinal.Add(objReporteEmp);
                            break;
                        }
                    }
                }

             for (int i = 0; i < listaFinal.Count; i++)
                {
                    reporte.contenido[i][0] = listaFinal[i].empleadoID;
                    reporte.contenido[i][1] = listaFinal[i].nombreCompleto;
                    reporte.contenido[i][2] = listaFinal[i].fecha.ToString();
                    reporte.contenido[i][3] = listaFinal[i].asistencia;
                }

            }
            catch 
            {
                for (int i = 10; i < x + 10; i++)
                {
                    reporte.contenido[i][0] = "cod =  " + i.ToString();
                    reporte.contenido[i][1] = "nomb = " + i.ToString();
                    reporte.contenido[i][2] = "fecha = " + i.ToString();
                    reporte.contenido[i][3] = "asist = " + i.ToString();
                }

            }
                                    

            return View("IndexReporteEmpleado", reporte);
        }
    }

}