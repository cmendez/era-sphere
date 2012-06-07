using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaOrdenCompra
    {
        EraSphereContext context = new EraSphereContext();



        public List<ProveedorView> retornar_ordenes()
        {
            LogicaProveedor lprov = new LogicaProveedor();
            return lprov.retornarProveedores();
        }

        public OrdenCompraView retornar_orden_nueva( int id_proveedor )
        {
            OrdenCompra Oc = new OrdenCompra();
            Oc.fecha_registro = System.DateTime.Now;
            Oc.proveedor = context.proveedores.Find( id_proveedor );
            Oc.estado_orden = context.estados_ocompra.Find(5);
            DBGenericQueriesUtil<OrdenCompra> query = 
                   new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            int id =  query.agregarElemento(Oc);
            Oc = context.ordenes_compra.Find(id);
            return new OrdenCompraView(Oc);
        }



        internal List< OCompraLineaView > retornar_lineas(int id_oc)
        {
            OrdenCompra oc = context.ordenes_compra.Find( id_oc );
            List<OCompraLineaView> ans = new List<OCompraLineaView>();
            foreach (var o in oc.productos) ans.Add(new OCompraLineaView(o));
            return ans;
        }

        internal void eliminar_linea(int id_oc, int id)
        {

            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = context.ordenes_clinea.Find(id);
            oc.productos.Remove( ocl );
            return;
           
        }

        internal void insertar_linea(int id_oc, int id_producto, int cantidad)
        {
            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = new OCompraLinea();
            ocl.producto = context.p_x_p.Find( id_producto );
            ocl.precio_total = (decimal)cantidad * (decimal)ocl.producto.precio_unitario;
            ocl.orden_compra = oc;
            DBGenericQueriesUtil<OrdenCompra> q = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            DBGenericQueriesUtil<OCompraLinea> ql = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            int id =ql.agregarElemento(ocl);
            ocl = context.ordenes_clinea.Find(id);
            oc.productos.Add(ocl);
            q.modificarElemento(oc, oc.ID);
        }
    }
}