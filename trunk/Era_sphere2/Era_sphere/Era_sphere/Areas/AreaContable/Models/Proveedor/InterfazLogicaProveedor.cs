using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public interface InterfazLogicaProveedor
    {
        EraSphereContext context_publico { get; }
        void agregarProveedor(ProveedorView proveedor);
        void modificarProveedor(ProveedorView proveedor);
        void eliminarProveedor(int proveedor_id);
        List<ProveedorView> retornarProveedores();
        ProveedorView retornarProveedor(int proveedor_id);
    }
}
