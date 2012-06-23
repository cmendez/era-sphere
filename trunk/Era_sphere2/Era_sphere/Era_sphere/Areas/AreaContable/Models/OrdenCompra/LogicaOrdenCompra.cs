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
        

        public LogicaOrdenCompra()
        {
            qoc = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            qocl = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            q_hotel = new DBGenericQueriesUtil<Hotel>(context, context.hoteles);
        }

        public List<ProveedorView> retornar_proveedores(int id_hotel)
        {
            LogicaHotel logica = new LogicaHotel();
            List<Proveedor> list = q_hotel.retornarUnSoloElemento(id_hotel).proveedores.ToList();
            List<ProveedorView> proveedores = new List<ProveedorView>();
            foreach (var x in list) { proveedores.Add(new ProveedorView(x)); }
            return proveedores;
        }

        public OrdenCompraView retornar_orden_nueva(int id_proveedor, int id_hotel)
        {
            OrdenCompra Oc = new OrdenCompra();
            Oc.fecha_registro = System.DateTime.Now;
            Oc.proveedor = context.proveedores.Find(id_proveedor);
            Oc.estado_orden = context.estados_ocompra.Find(1);
            Oc.hotel = q_hotel.retornarUnSoloElemento(id_hotel);
            DBGenericQueriesUtil<OrdenCompra> query =
                   new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            int id = query.agregarElemento(Oc);
            Oc = context.ordenes_compra.Find(id);
            return new OrdenCompraView(Oc);
        }



        internal List<OCompraLineaView> retornar_lineas(int id_oc)
        {
            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            List<OCompraLineaView> ans = new List<OCompraLineaView>();
            foreach (var o in oc.productos) if (!o.eliminado) ans.Add(new OCompraLineaView(o));
            return ans;
        }

        internal void eliminar_linea(int id_oc, int id)
        {

            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = context.ordenes_clinea.Find(id);
            DBGenericQueriesUtil<OCompraLinea> q = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            q.eliminarElemento(id);
            oc.productos.Remove(ocl);
            DBGenericQueriesUtil<OrdenCompra> query = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            oc.update_precio_total();
            query.modificarElemento(oc, oc.ID);
            return;

        }

        internal void insertar_linea(int id_oc, int id_producto, int cantidad)
        {
            OrdenCompra oc = context.ordenes_compra.Find(id_oc);
            OCompraLinea ocl = new OCompraLinea();
            ocl.producto = context.p_x_p.Find(id_producto);
            ocl.cantidad = cantidad;
            ocl.precio_total = (decimal)cantidad * (decimal)ocl.producto.precio_unitario;
            ocl.precio_unitario = (decimal)ocl.producto.precio_unitario;
            ocl.orden_compra = oc;
            
            DBGenericQueriesUtil<OrdenCompra> q = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            DBGenericQueriesUtil<OCompraLinea> ql = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
            int id = ql.agregarElemento(ocl);
            ocl = context.ordenes_clinea.Find(id);
            oc.productos.Add(ocl);
            oc.update_precio_total();
            q.modificarElemento(oc, oc.ID);
        }

        internal void elimina_orden_compra(int id_oc)
        {
            var list = ( from item in qoc.retornarUnSoloElemento(id_oc).productos 
                       select item.ID ).ToList();
            foreach (var item in list ) qocl.eliminarElemento(item);
            qoc.eliminarElemento(id_oc);
        }

        internal List<OrdenCompraView> retornar_ordenes_compra(int id_hotel)
        {
      /*      return new List<OrdenCompraView>{
                                new OrdenCompraView{ ordenID = 1, fecha_envio = DateTime.Now , fecha_llegada = DateTime.Now , 
                                                     estado_orden = "estado 1" , monto_total = (decimal)10.2 , fecha_registro = DateTime.Now ,
                                                     nro_productos = 10 , razon_proveedor = "Proveedor 1" , proveedorID = 12 ,
                                                     comentarios = "Este es un test - 1"},
                                
                                new OrdenCompraView{ ordenID = 2, fecha_envio = DateTime.Now , fecha_llegada = DateTime.Now , 
                                                     estado_orden = "estado 2" , monto_total = (decimal)104.2 , fecha_registro = DateTime.Now ,
                                                     nro_productos = 10 , razon_proveedor = "Proveedor 2" , proveedorID = 12 ,
                                                     comentarios = "Este es un test - 2"},
                                
                                new OrdenCompraView{ ordenID = 3, fecha_envio = DateTime.Now , fecha_llegada = DateTime.Now , 
                                                     estado_orden = "estado 3" , monto_total = (decimal)130.2 , fecha_registro = DateTime.Now ,
                                                     nro_productos = 10 , razon_proveedor = "Proveedor 3" , proveedorID = 12 ,
                                                     comentarios = "Este es un test - 3"},
            };*/
            List<OrdenCompra> list_oc = qoc.retornarTodos().Where(oc => oc.hotelID == id_hotel).ToList();
            List<OrdenCompraView> ans = new List<OrdenCompraView>();
            foreach (var oc in list_oc) ans.Add(new OrdenCompraView(oc));
            return ans;
        }

        internal List<OrdenCompraView> retornar_ordenes_compra()
        {
            List<OrdenCompra> list_oc = qoc.retornarTodos().ToList();
            List<OrdenCompraView> ans = new List<OrdenCompraView>();
            foreach (var oc in list_oc) ans.Add(new OrdenCompraView(oc));
            return ans;
        }

        internal void terminar_orden_compra(int id)
        {
            var oc = qoc.retornarUnSoloElemento(id);
            oc.fecha_llegada = DateTime.Now;
            oc.estado_orden = context.estados_ocompra.Find(4);
            qoc.modificarElemento(oc, oc.ID);
        }

        internal void aceptar_orden_compra(int id_orden)
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

        internal void cancelar_orden_compra(int id_orden)
        {
            var oc = qoc.retornarUnSoloElemento(id_orden);
            oc.estado_orden = context.estados_ocompra.Find(5);
            qoc.modificarElemento(oc, oc.ID);
        }

        internal List<OrdenCompraView> retornar_ordenes_compra_estado(int id_hotel)
        {
            return retornar_ordenes_compra( id_hotel).Where( oc => oc.estadoID == 2 ).ToList();
        }

        internal void modificar_orden_compra_linea(OCompraLineaView ocl_view)
        {
            OCompraLinea ocl_model = qocl.retornarUnSoloElemento(ocl_view.ID);
            if (ocl_view.cantidad <= 0) throw new Exception("Ingrese un numero mayor que 0");
            ocl_model.cantidad = ocl_view.cantidad;
            
            ocl_model.precio_total = ocl_model.cantidad * (decimal)ocl_model.precio_unitario;
            OrdenCompra oc = ocl_model.orden_compra;
            oc.update_precio_total();
            qocl.modificarElemento(ocl_model, ocl_model.ID);
            qoc.modificarElemento(oc, oc.ID);
        }

        internal OrdenCompraView retornar_orden(int id)
        {
            var oc = qoc.retornarUnSoloElemento(id);
            return new OrdenCompraView(oc);
        }
        internal List<OrdenCompraView>retornar_ordenes_compra_estado(int id_hotel, int estado_orden)
        {
            List<OrdenCompraView> ans = retornar_ordenes_compra(id_hotel).Where( oc => oc.estadoID == estado_orden ).ToList();
            return ans;
        }


    }
}