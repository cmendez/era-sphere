using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaProveedor:InterfazLogicaProveedor
    {
        EraSphereContext proveedor_context = new EraSphereContext();
        public EraSphereContext context_publico { get { return proveedor_context; } }
        DBGenericQueriesUtil<Proveedor> database_table;

        public LogicaProveedor() {
            database_table = new DBGenericQueriesUtil<Proveedor>(proveedor_context, proveedor_context.proveedores);
        }

        public void agregarProveedor(ProveedorView proveedor)
        {
            database_table.agregarElemento( proveedor.deserializa( this ) );  
        }

        public void modificarProveedor(ProveedorView proveedor_view)
        {
            Proveedor proveedor = proveedor_view.deserializa( this );
            database_table.modificarElemento(proveedor, proveedor.ID);
            return;
        }

        public void eliminarProveedor(int proveedor_id)
        {
            database_table.eliminarElemento(proveedor_id);
            return;
        }

        public List<ProveedorView> retornarProveedores()
        {
            List<Proveedor> proveedores = database_table.retornarTodos();
            List<ProveedorView> proveedores_view = new List<ProveedorView>();

            foreach (Proveedor proveedor in proveedores) proveedores_view.Add(new ProveedorView(proveedor));
            return proveedores_view;
        }

        public ProveedorView retornarProveedor(int proveedor_id)
        {
            Proveedor proveedor = database_table.retornarUnSoloElemento(proveedor_id);
            ProveedorView proveedor_view = new ProveedorView( proveedor );
            return proveedor_view;
        }
    }
}