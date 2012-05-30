using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaProducto : InterfazLogicaProducto
    {
        EraSphereContext producto_context = new EraSphereContext();
        DBGenericQueriesUtil<Producto> database_table;

        public LogicaProducto()
        {
            database_table = new DBGenericQueriesUtil<Producto>(producto_context, producto_context.productos);
        }
        public void agregarProducto(ProductoView producto)
        {
            database_table.agregarElemento(producto.deserializa(this));
        }
        public void modificarProducto(ProductoView producto_view)
        {
            Producto producto = producto_view.deserializa(this);
            database_table.modificarElemento(producto, producto.ID);
            return;
        }
        public void eliminarProducto(int producto_id)
        {
            database_table.eliminarElemento(producto_id);
            return;
        }
        public List<ProductoView> retornarProductos()
        {
            List<Producto> productos = database_table.retornarTodos();
            List<ProductoView> productos_view = new List<ProductoView>();

            foreach (Producto producto in productos) productos_view.Add(new ProductoView(producto));
            return productos_view;
        }

        public ProductoView retornarProducto(int producto_id)
        {
            Producto producto = database_table.retornarUnSoloElemento(producto_id);
            ProductoView producto_view = new ProductoView(producto);
            return producto_view;
        }
    }
}