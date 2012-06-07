using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaProveedor : InterfazLogicaProveedor
    {
        EraSphereContext proveedor_context = new EraSphereContext();
        public EraSphereContext context_publico { get { return proveedor_context; } }
        DBGenericQueriesUtil<Proveedor> database_table;

        public LogicaProveedor()
        {
            database_table = new DBGenericQueriesUtil<Proveedor>(proveedor_context, proveedor_context.proveedores);
        }

        public void agregarProveedor(ProveedorView proveedor)
        {
            database_table.agregarElemento(proveedor.deserializa(this));
        }

        public void modificarProveedor(ProveedorView proveedor_view)
        {
            Proveedor proveedor = proveedor_view.deserializa(this);
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
            ProveedorView proveedor_view = new ProveedorView(proveedor);
            return proveedor_view;
        }
        #region Productos
        public List< proveedor_x_productoView > productos_de_proveedor( int proveedor_id ){
            
           
            Proveedor proveedor = proveedor_context.proveedores.Find( proveedor_id );
            List<proveedor_x_producto> ans = proveedor.productos.ToList();
            List<proveedor_x_productoView> ret = new List<proveedor_x_productoView>();
            foreach (proveedor_x_producto pp in ans) { 
                proveedor_x_productoView ppv = new proveedor_x_productoView( pp );
                ret.Add(ppv);
            }
            return ret;
        }

        public List<ProductoView> productosRestantes( string text , int proveedor_id) {

            List<Producto> usados = new List<Producto>();
            List<proveedor_x_producto> relacion = proveedor_context.proveedores.Find(proveedor_id).productos.ToList();
            foreach (proveedor_x_producto pp in relacion) usados.Add(proveedor_context.productos.Find(pp.productoID));
            List<Producto> resta;
            if (text != null)
                resta = proveedor_context.productos.Where(p => p.descripcion.StartsWith(text)).ToList();
            else
                resta = proveedor_context.productos.ToList();
            foreach (var p in usados) resta.Remove(p);
            List<ProductoView> ans = new List<ProductoView>();
            foreach (var p in resta) ans.Add(new ProductoView(p));
            return ans;
        }

        public void agregarProductoAProveedor(int id, proveedor_x_productoView ppv)
        {
            EraSphereContext context = proveedor_context;
            proveedor_x_producto pp = new proveedor_x_producto();

            IEnumerable<proveedor_x_producto> ans = from producto in context.p_x_p
                                                    where producto.productoID == ppv.productoID && producto.proveedorID == id
                                                    select producto;
            List<proveedor_x_producto> ret = ans.ToList();
            if (ret.Count != 0) {
                ppv.ID = ret.ElementAt(0).ID;
                modificar_producto(id, ppv);
                return;
            }
                                                    

            pp.precio_unitario = ppv.precio_unitario;
            pp.proveedor = context.proveedores.Find(id);
            pp.producto = context.productos.Find( ppv.productoID ) ;
            DBGenericQueriesUtil<proveedor_x_producto> query = new DBGenericQueriesUtil<proveedor_x_producto>(context, context.p_x_p);
            query.agregarElemento(pp);
        }

        internal void modificar_producto(int id_proveedor, proveedor_x_productoView producto)
        {
            EraSphereContext context = proveedor_context;
            proveedor_x_producto pp = context.p_x_p.Find(producto.ID);
            pp.precio_unitario = producto.precio_unitario;
            DBGenericQueriesUtil<proveedor_x_producto> query = new DBGenericQueriesUtil<proveedor_x_producto>(context, context.p_x_p);
            query.modificarElemento(pp, pp.ID);
        }

        internal void eliminar_producto(int id_proveedor, proveedor_x_productoView producto)
        {
            EraSphereContext context = proveedor_context;
            proveedor_x_producto pp = context.p_x_p.Find(producto.ID);
            context.p_x_p.Remove(pp);
            context.SaveChanges();
        }
        #endregion
        #region Hoteles
        public List< HotelView > hoteles_de_proveedor( int id_proveedor )
        {
            EraSphereContext context = proveedor_context;
            Proveedor proveedor = context.proveedores.Find( id_proveedor );
            List<Hotel> hoteles = proveedor.hoteles.ToList();
            //List<Hotel> hoteles = context.hoteles.ToList();
            List<HotelView> ans = new List<HotelView>(); 
            foreach (var h in hoteles) { 
                ans.Add( new HotelView( h ) ) ;
            }
            return ans;
        }


        internal void elimina_hotel(int id_proveedor, HotelView hotelv )
        {
            EraSphereContext context = proveedor_context;
            Proveedor proveedor = context.proveedores.Find(id_proveedor);
            Hotel hotel = context.hoteles.Find(hotelv.ID);
            proveedor.hoteles.Remove(hotel);
            save_proveedor(proveedor, id_proveedor);
        }

        internal void agregar_hotel_proveedor(int id_proveedor, int id_hotel)
        {

            EraSphereContext context = proveedor_context;
            Proveedor proveedor = context.proveedores.Find(id_proveedor);
            Hotel hotel = context.hoteles.Find(id_hotel);
            proveedor.hoteles.Add(hotel);
            save_proveedor(proveedor, id_proveedor);
        }

        internal List<HotelView> hoteles_restantes(string text, int id_proveedor)
        {
            EraSphereContext context = proveedor_context;
            Proveedor proveedor = context.proveedores.Find(id_proveedor);
            List<Hotel> usados = proveedor.hoteles.ToList() ;
            List<Hotel> hoteles;
            if( text != null ) {
                hoteles = context.hoteles.Where( h => h.razon_social.StartsWith( text ) ).ToList();
            }
            else{
                hoteles = context.hoteles.ToList();
            }
            foreach (var h in usados) hoteles.Remove(h);
            List<HotelView> ans = new List<HotelView>();
            foreach (var h in hoteles) ans.Add(new HotelView(h));
            return ans;
        }

        #endregion

        #region Utils
        void save_proveedor(Proveedor proveedor , int id_proveedor ) {
            EraSphereContext context = proveedor_context;
            DBGenericQueriesUtil<Proveedor> query = new DBGenericQueriesUtil<Proveedor>(context, context.proveedores);
            query.modificarElemento(proveedor, id_proveedor);
        }
        #endregion

       
    }
}