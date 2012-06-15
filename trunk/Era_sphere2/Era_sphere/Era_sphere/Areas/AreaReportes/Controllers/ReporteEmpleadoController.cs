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

            reporte.cabecera = new String[2, 6]
                {
                    {"Codigo","Nombre Completo","Fecha", "Hora Entrada", "Hora Salida", "Asistencia"},
                    {"","","","","",""}
                 
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

            if (listaEmpleadosFiltrada.Count == 0)
            {
                listaEmpleadosFiltrada = listaEmpleados;
            }

            /*if (formReporte.apePaterno != null)
                listaEmpleados.Where(e => e.apellido_paterno.Contains(formReporte.apePaterno));

            if (formReporte.apeMaterno != null)
                listaEmpleados.Where(e => e.apellido_materno.Contains(formReporte.apeMaterno));*/

            //formReporte.fechaInicio.AddMinutes(43);

            //try catch
            try
            {
                     string f1 = formReporte.fechaInicio.ToShortDateString();

                    foreach (AsistenciaEmpleado asisEmp in listaAsistencias)
                    {
                        if ((asisEmp.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaInicio.ToString()) > 0) ||          
                                (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f1))
                        {

                                string f2 = formReporte.fechaFin.ToShortDateString();

                                 if ((asisEmp.fechaHoraEntrada.ToString().CompareTo(formReporte.fechaFin.ToString()) < 0) ||     
                                      (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f2))
                                       /* if (!listaAsistenciasFiltrada.Contains(asisEmp))
                                            listaAsistenciasFiltrada.Add(asisEmp);*/
                                     listaAsistenciasFiltrada.Add(asisEmp);
                        }
                    }
                    


                ObjetoReporteEmpleado objReporteEmp;
                
                foreach (AsistenciaEmpleado asistencia in listaAsistenciasFiltrada)
                {
                    foreach (Empleado empleados in listaEmpleadosFiltrada)
                    {
                        if (Int32.Parse(asistencia.empleadoID) == empleados.ID)
                        {
                            objReporteEmp = new ObjetoReporteEmpleado();
                            try
                            {
                                objReporteEmp.empleadoID = empleados.ID.ToString();
                            }
                            catch 
                            {
                                objReporteEmp.empleadoID = "";
                            }

                            try
                            {
                                objReporteEmp.nombreCompleto = empleados.nombre + " " + empleados.apellido_paterno + " " + empleados.apellido_materno;
                            }
                            catch
                            {
                                objReporteEmp.nombreCompleto = "";
                            }

                            try
                            {
                                objReporteEmp.fecha = asistencia.fechaHoraEntrada.Value.ToShortDateString();
                            }
                            catch
                            {
                                objReporteEmp.fecha = "";
                            }

                            try
                            {
                                objReporteEmp.horaEntrada = asistencia.fechaHoraEntrada.Value.ToShortTimeString();
                            }
                            catch
                            {
                                objReporteEmp.horaEntrada = "";
                            }

                            try
                            {
                                objReporteEmp.horaSalida = asistencia.fechaHoraSalida.Value.ToShortTimeString();
                            }
                            catch
                            {
                                objReporteEmp.horaSalida = "";
                            }

                            try
                            {
                                objReporteEmp.asistencia = asistencia.s_asistencia;
                            }
                            catch
                            {
                                objReporteEmp.asistencia = "";
                            }
                                                      
                            
                            listaFinal.Add(objReporteEmp);
                            break;
                        }
                    }
                }

             for (int i = 0; i < listaFinal.Count; i++)
                {
                    reporte.contenido[i][0] = listaFinal[i].empleadoID;
                    reporte.contenido[i][1] = listaFinal[i].nombreCompleto;
                    reporte.contenido[i][2] = listaFinal[i].fecha;
                    reporte.contenido[i][3] = listaFinal[i].horaEntrada;
                    reporte.contenido[i][4] = listaFinal[i].horaSalida;
                    reporte.contenido[i][5] = listaFinal[i].asistencia;
                }

            }
            catch 
            {
                for (int i = 10; i < x + 10; i++)
                {
                    reporte.contenido[i][0] = "ERROR";
                    reporte.contenido[i][1] = "EN LA";
                    reporte.contenido[i][2] = "GENERACION";
                    reporte.contenido[i][3] = "DEL";
                    reporte.contenido[i][4] = "REPORTE";
                    reporte.contenido[i][5] = "!!!!";
                }

            }
                                    

            return View("IndexReporteEmpleado", reporte);
        }
    }

}