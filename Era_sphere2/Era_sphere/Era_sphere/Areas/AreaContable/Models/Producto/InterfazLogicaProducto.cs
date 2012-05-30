using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaContable.Models
{
    public interface InterfazLogicaProducto
    {
        void agregarProducto(ProductoView producto);
        void modificarProducto(ProductoView producto);
        void eliminarProducto(int producto_id);
        List<ProductoView> retornarProductos();
        ProductoView retornarProducto(int hotel_id);
    }
}
