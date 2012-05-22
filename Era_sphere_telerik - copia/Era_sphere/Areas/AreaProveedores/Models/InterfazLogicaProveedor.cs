using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaProveedores.Models
{
    interface InterfazLogicaProveedor
    {
        List<Proveedor> retornarProveedores();
        Proveedor retornarProveedor(int proveedor_id);
        void modificarProveedor(Proveedor proveedor);
        void agregarProveedor(Proveedor proveedor);
        void eliminarProveedor(int proveedor_id);
        //revisar: "proveedor o no proveedor"
        List<Proveedor> buscarProveedor(Proveedor proveedor);
        EstadoProveedor retornarEstado(int estado_id);
    }
}