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
        void agregarProveedor(ProveedorView hotel);
        void modificarProveedor(ProveedorView hotel);
        void eliminarProveedor(int hotel_id);
        List<ProveedorView> retornarProveedores();
        ProveedorView retornarProveedor(int hotel_id);
    }
}
