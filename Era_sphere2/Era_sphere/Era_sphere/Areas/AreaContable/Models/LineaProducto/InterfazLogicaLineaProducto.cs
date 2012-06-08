using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Era_sphere.Areas.AreaContable.Models
{
    interface InterfazLogicaLineaProducto
    {
        void modificarLineaProducto(LineaProductoView lineaproducto);
        void agregarLineaProducto(LineaProductoView lineaproducto);
        void eliminarLineaProducto(int lineaproducto_id);
        List<LineaProductoView> retornarLineasProducto();
        LineaProductoView retornarLineaProducto(int lineaproducto_id);
        List<LineaProducto> buscarLineaProducto(LineaProducto lineaproducto);

    }
}
