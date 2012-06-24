using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaReportes.Models.ReporteEmpleados;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

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
            int x,y,z,s;

            x = 0;
            y = 0;
            z = 0;
            s = 0;

            ReporteEmpleado reporte = new ReporteEmpleado();
            List<Empleado> listaEmpleados = (new EraSphereContext()).empleados.ToList();
            List<Empleado> listaEmpleadosFiltrada = new List<Empleado>();
            List<AsistenciaEmpleado> listaAsistencias = (new EraSphereContext()).asistenciaEmpleado.ToList();
            List<AsistenciaEmpleado> listaAsistenciasFiltrada = new List<AsistenciaEmpleado>();
            List<ObjetoReporteEmpleado> listaFinal = new List<ObjetoReporteEmpleado>();
            List<Cadena> cadena = (new EraSphereContext()).cadenas.ToList();
            DateTime date = DateTime.Now;
            

            reporte.titulo = new String[6, 5]
            {
                    {"","REPORTE DE ASISTENCIAS","DE EMPLEADOS", " ", ""},
                    {"","","","",""},
                    {"CADENA",cadena[0].nombreCadena,"","FECHA",date.ToShortDateString()},
                    {"","","","",""},
                    {"","","","",""},
                    {"","","","",""}
            };

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
                x = 4;

            if (formReporte.apePaterno != null)
                y = 2;

            if (formReporte.apeMaterno != null)
                z = 1;

            s = x + y + z; /*Logica: cada campo del formulario representa un "bit" imaginario, donde la combinacion de los 3 nos                                dara una suma que puede ir de 0 a 8 (2^3)*/

            /*
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

            */


            //try catch
            try
            {
                    //filtrar lista de empleados mediante filtros de nombre y apellidos

                switch (s)
                { 
                    case 0: //listar TODOS
                        listaEmpleadosFiltrada = listaEmpleados;
                        break;

                    case 1: //filtrar por apellido materno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if (empl.apellido_materno.Contains(formReporte.apeMaterno))
                                    listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 2: //filtar por apellido paterno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if (empl.apellido_paterno.Contains(formReporte.apePaterno))
                                    listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 3: //por apellidos paterno y materno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if ((empl.apellido_materno.Contains(formReporte.apeMaterno)) && (empl.apellido_paterno.Contains                                        (formReporte.apePaterno)))
                                        listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 4: //por nombre
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if (empl.nombre.Contains(formReporte.nombre))
                                    listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 5: //por nombre y apellido materno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if ((empl.apellido_materno.Contains(formReporte.apeMaterno)) && (empl.nombre.Contains                                         (formReporte.nombre)))
                                        listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 6: //por nombre y apellido paterno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if ((empl.apellido_paterno.Contains(formReporte.apePaterno)) && (empl.nombre.Contains                                                   (formReporte.nombre)))
                                        listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                    case 7: //por nombre, apellido paterno y materno
                        foreach (Empleado empl in listaEmpleados)
                        {
                            try
                            {
                                if ((empl.apellido_materno.Contains(formReporte.apeMaterno)) && (empl.nombre.Contains                                                   (formReporte.nombre)) && (empl.apellido_paterno.Contains(formReporte.apePaterno)))
                                        listaEmpleadosFiltrada.Add(empl);
                            }
                            catch { }
                        }
                        break;

                
                }

                    

                    //filtrar listaasistencias mediante filtros de fechas inicio y fin
                    string f1 = formReporte.fechaInicio.ToShortDateString();

                    foreach (AsistenciaEmpleado asisEmp in listaAsistencias)
                    {
                        //string t;
                        /*if (DateTime.Compare((DateTime)asisEmp.fechaHoraEntrada, (DateTime)formReporte.fechaInicio) > 0)
                            t = " > ";
                        if (DateTime.Compare((DateTime)asisEmp.fechaHoraEntrada, (DateTime)formReporte.fechaInicio) < 0)
                            t = " < ";
                        */
                        //string aux = asisEmp.fechaHoraEntrada.Value.ToShortDateString();
                        /*int n = asisEmp.fechaHoraEntrada.Value.ToShortDateString().CompareTo(formReporte.fechaInicio.ToShortDateString());*/
                        if ((DateTime.Compare((DateTime)asisEmp.fechaHoraEntrada, (DateTime)formReporte.fechaInicio) > 0) ||                                          (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f1))
                        {

                                string f2 = formReporte.fechaFin.ToShortDateString();

                                if ((DateTime.Compare((DateTime)asisEmp.fechaHoraEntrada, (DateTime)formReporte.fechaFin) < 0) ||                                           (asisEmp.fechaHoraEntrada.Value.ToShortDateString() == f2))
                                       /* if (!listaAsistenciasFiltrada.Contains(asisEmp))
                                            listaAsistenciasFiltrada.Add(asisEmp);*/
                                     listaAsistenciasFiltrada.Add(asisEmp);
                        }
                    }
                    

                //hacemos el cruce entre asistencias y empleados

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
                //persons.Sort((p1,p2)=>string.Compare(p1.Name,p2.Name,true));

                listaFinal.Sort((p1, p2) => string.Compare(p1.empleadoID.ToString(), p2.empleadoID.ToString()));

                //llenamos el reporte
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
                for (int i = 10; i < 20; i++)
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