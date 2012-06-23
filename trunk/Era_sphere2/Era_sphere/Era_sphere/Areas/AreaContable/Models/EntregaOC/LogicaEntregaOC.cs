using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.Collections;
using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaEntregaOC
    {
        EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<EntregaOC> qeoc;
        DBGenericQueriesUtil<EOCLinea> qeocl;
        DBGenericQueriesUtil<OrdenCompra> query_oc;
        DBGenericQueriesUtil<OCompraLinea> query_ocl;
        public LogicaEntregaOC() {
            query_oc = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            qeoc = new DBGenericQueriesUtil<EntregaOC>(context, context.entregas_oc);
            qeocl = new DBGenericQueriesUtil<EOCLinea>(context , context.entrega_oc_linea);
            query_ocl = new DBGenericQueriesUtil<OCompraLinea>(context, context.ordenes_clinea);
        }

        internal void insertar_linea(int id_eoc, int id_productoa, int cantidada)
        {
            EOCLinea linea = new EOCLinea { 
                cantidad_entregada = cantidada,
                entrega = qeoc.retornarUnSoloElemento( id_eoc ),
                linea_oc = query_ocl.retornarUnSoloElemento( id_productoa )
            };
            if(linea.entrega == null || linea.cantidad_entregada < 0) throw new Exception("Ingrese datos validos");
            if( linea.linea_oc == null  ) throw new Exception("Ingrese datos validos");
            int falta = linea.linea_oc.cantidad - linea.linea_oc.cantidad_recibida;
            if (falta < cantidada) throw new Exception("Solo puede registrar " + falta + " productos como maximo");
            qeocl.agregarElemento(linea);
            var prod = query_ocl.retornarUnSoloElemento(id_productoa);
            prod.calcular_recibido();
            query_ocl.modificarElemento(prod, prod.ID);
        }

        public EntregaOCView crearEOC(int id_ordendecompra)
        {
            EntregaOC entrega = new EntregaOC();
            entrega.orden_compra = query_oc.retornarUnSoloElemento(id_ordendecompra);
            entrega.fecha_entrega = DateTime.Now;
            int id_entrega = qeoc.agregarElemento(entrega);
            entrega = qeoc.retornarUnSoloElemento(id_entrega);
            EntregaOCView ans = new EntregaOCView( entrega ) ;
            return ans;
        }

        public List<ComboEntregaItem> retornar_lineas_restantes(int id_oc)
        {
            OrdenCompra oc = query_oc.retornarUnSoloElemento(id_oc);
            List<OCompraLinea > lineas = oc.productos.ToList();
            List<OCompraLinea> ans_ocl = ( from linea in lineas
                                       where linea.eliminado == false && linea.cantidad_recibida < linea.cantidad  
                                       select linea).ToList();
            List<ComboEntregaItem> ans = new List<ComboEntregaItem>();
            foreach (var item in ans_ocl) ans.Add(new ComboEntregaItem ( item ));
            return ans;
        }

        public List<EOCLineaView> retornar_entrega_lineas(int id_eoc)
        {
            EntregaOC entrega = qeoc.retornarUnSoloElemento(id_eoc);
            List<EOCLineaView> ans = (from item in entrega.productos
                                      where item.eliminado == false
                                      select new EOCLineaView(item)).ToList(); 
            return ans;
        }

        internal void modificar_entrega_linea(EOCLineaView entrega_linea)
        {
            int id = entrega_linea.ID;
            int cantidad = entrega_linea.cantidad;
            if (cantidad == 0) throw new Exception("El nro de productos entregados debe ser mayor a 0"); 
            var e_linea = qeocl.retornarUnSoloElemento( id );
            var o_linea = query_ocl.retornarUnSoloElemento( e_linea.linea_oc.ID );
            int falta = o_linea.cantidad - ( o_linea.cantidad_recibida - e_linea.cantidad_entregada );
            if (falta < cantidad) throw new Exception("Solo puede registrar " + falta + " productos como maximo");
            e_linea.cantidad_entregada = cantidad;
            qeocl.modificarElemento(e_linea, e_linea.ID);
            o_linea = query_ocl.retornarUnSoloElemento(o_linea.ID);
            o_linea.calcular_recibido();
            query_ocl.modificarElemento(o_linea, o_linea.ID);
        }

        internal void elimina_entrega_linea(int id)
        {
            var linea = qeocl.retornarUnSoloElemento(id);
            int oc_id = linea.linea_ocID;
            qeocl.eliminarElemento(id);
            var oc_linea = query_ocl.retornarUnSoloElemento(oc_id);
            oc_linea.calcular_recibido();
            query_ocl.modificarElemento(oc_linea, oc_linea.ID);
        }

        internal void eliminar_entrega(int id_eoc)
        {
            var eoc = qeoc.retornarUnSoloElemento(id_eoc);
            List<int> afected = (from item in eoc.productos
                                          where item.eliminado == false
                                          select item.linea_oc.ID).ToList(); 
            qeoc.eliminarElemento(id_eoc);
            foreach (var item in afected)
            {
                var linea = query_ocl.retornarUnSoloElemento( item );
                linea.calcular_recibido();
                query_ocl.modificarElemento(linea, item);
            }
        }

        internal List<EntregaOCView> retornar_entregas(int id_oc)
        {
            var oc = query_oc.retornarUnSoloElemento(id_oc);
            var lista = oc.entregas;
            List<EntregaOCView> ans = ( from item in lista
                                        where item.eliminado == false
                                        select new EntregaOCView( item ) ).ToList();
            return ans;
        }

        internal EntregaOCView retornar_entrega(int id_eoc)
        {
            var ans = new EntregaOCView( qeoc.retornarUnSoloElemento(id_eoc) );
            return ans;
        }

        internal List< EOCLineaView > retornar_detalle_eoc(int id_oc)
        {
            List<EOCLinea> ans = (from item in context.entrega_oc_linea
                                      where item.eliminado == false && item.linea_oc.orden_compraID == id_oc
                                      select item
                                             ).ToList();
            List<EOCLineaView> ret = new List<EOCLineaView>();
            foreach (var item in ans) ret.Add(new EOCLineaView(item)); 
            return ret;
        }
    }
}