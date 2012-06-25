using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaLineaProducto : InterfazLogicaLineaProducto
    {
        EraSphereContext lineaproducto_context = new EraSphereContext();
        DBGenericQueriesUtil<LineaProducto> database_table;

        public LogicaLineaProducto()
        {
            database_table = new DBGenericQueriesUtil<LineaProducto>(lineaproducto_context, lineaproducto_context.lineasproducto);
        }

        public List<LineaProductoView> retornarLineasProducto()
        {
            List<LineaProducto> lineasproducto = database_table.retornarTodos();
            List<LineaProductoView> lineasproducto_view = new List<LineaProductoView>();

            foreach (LineaProducto lineaproducto in lineasproducto) lineasproducto_view.Add(new LineaProductoView(lineaproducto));
            return lineasproducto_view;
        }

        public LineaProductoView retornarLineaProducto(int lineaproductoID)
        {
            LineaProducto lineaproducto_aux = database_table.retornarUnSoloElemento(lineaproductoID);
            LineaProductoView lineaproducto = new LineaProductoView(lineaproducto_aux);
            return lineaproducto;
        }

        public void modificarLineaProducto(LineaProductoView lineaproducto_view)
        {
            LineaProducto lineaproducto = lineaproducto_view.deserializa(this);
            LineaProducto orig = database_table.retornarUnSoloElemento(lineaproducto_view.ID);
            orig.descripcion = lineaproducto.descripcion ?? orig.descripcion;
            database_table.modificarElemento(orig, lineaproducto.ID);
        }

        public void agregarLineaProducto(LineaProductoView lineaproducto)
        {
            database_table.agregarElemento(lineaproducto.deserializa(this));
        }

        public void eliminarLineaProducto(int lineaproductoID)
        {
            database_table.eliminarElemento_logico(lineaproductoID);
        }

        public List<LineaProducto> buscarLineaProducto(LineaProducto lineaproducto_campos)
        {
            return database_table.buscarElementos(lineaproducto_campos);
        }






        public List<LineaProducto> retornarTodos()
        {
            return database_table.retornarTodos();
        }


    }
}