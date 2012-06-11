using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaOrdenCompra
    {

        EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<OrdenCompra> qoc;
        DBGenericQueriesUtil<OCompraLinea> qocl;
        DBGenericQueriesUtil<Hotel> q_hotel;
      

        public LogicaOrdenCompra(){
            qoc = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            qocl = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            q_hotel = new DBGenericQueriesUtil<Hotel>(context, context.hoteles);
        }

        public List<ProveedorView> retornar_proveedores( int id_hotel )
        {
            LogicaHotel logica = new LogicaHotel();
            List<Proveedor> list = q_hotel.retornarUnSoloElemento( id_hotel ).proveedores.ToList();
            List<ProveedorView> proveedores = new List<ProveedorView>();
            foreach (var x in list) { proveedores.Add(new ProveedorView(x)); }
            return proveedores;
        }

        public OrdenCompraView retornar_orden_nueva( int id_proveedor , int id_hotel )
        {
            OrdenCompra Oc = new OrdenCompra();
            Oc.fecha_registro = System.DateTime.Now;
            Oc.proveedor = context.proveedores.Find( id_proveedor );
            Oc.estado_orden = context.estados_ocompra.Find(5);
            Oc.hotel = q_hotel.retornarUnSoloElemento(id_hotel);
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
            foreach (var o in oc.productos) if( !o.eliminado ) ans.Add(new OCompraLineaView(o));
            return ans;
        }

        internal void eliminar_linea(int id_oc, int id)
        {

            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = context.ordenes_clinea.Find(id);
            DBGenericQueriesUtil<OCompraLinea> q = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            q.eliminarElemento(id);
            oc.productos.Remove( ocl ); 
            DBGenericQueriesUtil<OrdenCompra> query = new DBGenericQueriesUtil<OrdenCompra>(context,context.ordenes_compra);
            query.modificarElemento(oc, oc.ID);
            return;
           
        }

        internal void insertar_linea(int id_oc, int id_producto, int cantidad)
        {
            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = new OCompraLinea();
            ocl.producto = context.p_x_p.Find( id_producto );
            ocl.cantidad = cantidad;
            ocl.precio_total = (decimal)cantidad * (decimal)ocl.producto.precio_unitario;
            ocl.orden_compra = oc;
            DBGenericQueriesUtil<OrdenCompra> q = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            DBGenericQueriesUtil<OCompraLinea> ql = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            int id =ql.agregarElemento(ocl);
            ocl = context.ordenes_clinea.Find(id);
            oc.productos.Add(ocl);
            q.modificarElemento(oc, oc.ID);
        }

        internal void elimina_orden_compra(int id_oc)
        {
            qoc.eliminarElemento( id_oc );
        }

        internal List<OrdenCompraView> retornar_ordenes_compra()
        {
            List<OrdenCompra> list_oc = qoc.retornarTodos();
            List<OrdenCompraView> ans = new List<OrdenCompraView>();
            foreach (var oc in list_oc) ans.Add( new OrdenCompraView( oc ));
            return ans;
        }

        internal void enviar_orden_compra(int id_orden)
        {
            var oc = qoc.retornarUnSoloElemento(id_orden);
            oc.fecha_envio = DateTime.Now;
            oc.estado_orden = context.estados_ocompra.Find(3);
            qoc.modificarElemento(oc, oc.ID);
        }

        internal void registar_orden_compra(int id_oc)
        {
            var oc = qoc.retornarUnSoloElemento(id_oc);
            oc.fecha_registro = DateTime.Now;
            oc.estado_orden = context.estados_ocompra.Find(2);
            qoc.modificarElemento(oc, oc.ID);
        }

        internal void cancelar_orden_compra(int id_orden) {
            var oc = qoc.retornarUnSoloElemento(id_orden);
            oc.estado_orden = context.estados_ocompra.Find(5);
            qoc.modificarElemento(oc, oc.ID);
        }
    }
}