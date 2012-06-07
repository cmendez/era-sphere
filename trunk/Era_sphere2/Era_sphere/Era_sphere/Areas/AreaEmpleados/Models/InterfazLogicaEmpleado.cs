using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Era_sphere.Areas.AreaEmpleados.Models
{
    public interface InterfazLogicaEmpleado
    {
        List<EmpleadoView> retornarEmpleados();
        Empleado retornarEmpleado(int empleado_id);
        void modificarEmpleado(Empleado empleado);
        void agregarEmpleado(Empleado empleado);
        void eliminarEmpleado(int empleado_id);
        List<Empleado> buscarEmpleado(Empleado empleado);
    }
}