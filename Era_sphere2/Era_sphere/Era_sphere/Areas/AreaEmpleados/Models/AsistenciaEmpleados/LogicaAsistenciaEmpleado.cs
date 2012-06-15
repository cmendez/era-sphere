using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;



namespace Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados
{
    public class LogicaAsistenciaEmpleado : InterfazLogicaAsistenciaEmpleado
    {
        EraSphereContext asistenciaEmpleado_context = new EraSphereContext();
        DBGenericQueriesUtil<AsistenciaEmpleado> database_table;


        public LogicaAsistenciaEmpleado()
        {
            database_table = new DBGenericQueriesUtil<AsistenciaEmpleado>(asistenciaEmpleado_context, asistenciaEmpleado_context.asistenciaEmpleado);
        }

        public void agregarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado)
        {
            database_table.agregarElemento(AsistenciaEmpleado);
        }
        /*
        public List<AsistenciaEmpleado> retornarAsistenciaEmpleados()
        {
            return database_table.retornarTodos();
        }

        public AsistenciaEmpleado retornarAsistenciaEmpleado(int AsistenciaEmpleadoID)
        {
            return database_table.retornarUnSoloElemento(AsistenciaEmpleadoID);
        }

        public void modificarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado)
        {
            database_table.modificarElemento(AsistenciaEmpleado, AsistenciaEmpleado.ID);
        }



        public void eliminarAsistenciaEmpleado(int AsistenciaEmpleadoID)
        {
            database_table.eliminarElemento(AsistenciaEmpleadoID);
        }

        public List<AsistenciaEmpleado> buscarAsistenciaEmpleado(AsistenciaEmpleado AsistenciaEmpleado_campos)
        {
            return database_table.buscarElementos(AsistenciaEmpleado_campos);
        }

        */

        public bool validarRegistro(int idEmpleado, DateTime fechaActual, int tipo)
        {
            List<AsistenciaEmpleado> asistencias = database_table.retornarTodos();

            string s_fechaActual = fechaActual.ToShortDateString(); //DD/MM/YYYY
            
            if (tipo == 1)
            {
                foreach (AsistenciaEmpleado asistencia in asistencias)
                    if ((Int32.Parse(asistencia.empleadoID) == idEmpleado) && (asistencia.fechaHoraEntrada.Value.ToShortDateString() == s_fechaActual))
                        return true;
            }
            else if (tipo==2)
            {
                foreach (AsistenciaEmpleado asistencia in asistencias)
                    try 
                    {
                       if ((Int32.Parse(asistencia.empleadoID) == idEmpleado) && 
                                asistencia.fechaHoraSalida.Value.ToShortDateString() == s_fechaActual)
                        return true;
                    }
                    catch
                    {}
                        
            }
            return false;
        }

        public bool existeEntrada(int idEmpleado, DateTime fechaActual)
        {
            string s_fechaActual = fechaActual.ToShortDateString(); //DD/MM/YYYY
            
            List<AsistenciaEmpleado> asistencias = database_table.retornarTodos();

            foreach (AsistenciaEmpleado asistencia in asistencias)
                if ((Int32.Parse(asistencia.empleadoID) == idEmpleado) && (asistencia.fechaHoraEntrada.Value.ToShortDateString() == s_fechaActual))
                    return true;

            return false;
        }

        public void modificarAsistenciaEmpleado(int idEmpleado, DateTime fechaActual)
        {
            string s_fechaActual = fechaActual.ToShortDateString(); //DD/MM/YYYY

            List<AsistenciaEmpleado> asistencias = database_table.retornarTodos();

            foreach (AsistenciaEmpleado asistencia in asistencias)
                if ((Int32.Parse(asistencia.empleadoID) == idEmpleado) && (asistencia.fechaHoraEntrada.Value.ToShortDateString() == s_fechaActual))
                {
                    asistencia.fechaHoraSalida = fechaActual;
                    asistencia.s_asistencia = "ASISTENCIA COMPLETA";
                    database_table.modificarElemento(asistencia, asistencia.ID);
                    return;
                }


        }

        public List<AsistenciaEmpleadoView> retornarAsistencias(int id)
        {
            List<AsistenciaEmpleado> asistencias = database_table.retornarTodos();
            List<AsistenciaEmpleadoView> asistencias_view = new List<AsistenciaEmpleadoView>();

            //asistencias.Where(a => (Int32.Parse(a.empleadoID) == id));


            foreach (AsistenciaEmpleado asistencia in asistencias)
            {
               //YETI CON ESTO SOLO MOSTRARA LAS ASISTENCIAS DEL EMPLEADO QUE ESTE LOGEADO, NO DE TODOS
                
             //   if (Int32.Parse(asistencia.empleadoID) == id)
                    asistencias_view.Add(new AsistenciaEmpleadoView(asistencia));
            }
            return asistencias_view;
        }


        /*public List<PromocionView> retornarPromociones()
        {
            List<Promocion> promociones = database_table.retornarTodos();
            List<PromocionView> promociones_view = new List<PromocionView>();

            foreach (Promocion promocion in promociones) promociones_view.Add(new PromocionView(promocion));
            return promociones_view;
        } */
    }
}