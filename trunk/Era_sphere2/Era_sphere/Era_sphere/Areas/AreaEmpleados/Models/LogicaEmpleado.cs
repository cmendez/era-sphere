using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEmpleados.Models;

 
namespace Era_sphere.Areas.AreaEmpleados.Models
{
    public class LogicaEmpleado : InterfazLogicaEmpleado
    {
        public EraSphereContext empleado_context = new EraSphereContext();
        DBGenericQueriesUtil<Empleado> database_table;


        public LogicaEmpleado()
        {
            database_table = new DBGenericQueriesUtil<Empleado>(empleado_context, empleado_context.empleados);
        }


        public List<EmpleadoView> loginEmpleado(String user, String password)
        {
            List<Empleado> empleados = database_table.retornarTodos();
            List<EmpleadoView> empleados_view = new List<EmpleadoView>();

            foreach (Empleado empleado in empleados) 
                if (empleado.usuario == user && empleado.password == password) 
                     empleados_view.Add(new EmpleadoView(empleado));
            return empleados_view;
        }

        public List<EmpleadoView> retornarEmpleados()
        {

            List<Empleado> empleados = database_table.retornarTodos();
            List<EmpleadoView> empleados_view = new List<EmpleadoView>();

            foreach (Empleado empleado in empleados) empleados_view.Add(new EmpleadoView(empleado));
            return empleados_view;
        }


        public EmpleadoView retornarEmpleado(int empleadoID)
        {
            Empleado emp =  database_table.retornarUnSoloElemento(empleadoID);
            EmpleadoView empleado = new EmpleadoView(emp);
            return empleado;
        }

        public void modificarEmpleado(Empleado empleado)
        {
            database_table.modificarElemento(empleado, empleado.ID);
        }

        public void agregarEmpleado(Empleado empleado)
        {
            database_table.agregarElemento(empleado);
        }

        public void eliminarEmpleado(int empleadoID)
        {
            database_table.eliminarElemento(empleadoID);
        }

        public List<Empleado> buscarEmpleado(Empleado empleado_campos)
        {
            return database_table.buscarElementos(empleado_campos);
        }

    }
}