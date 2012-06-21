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

        public LogicaEntregaOC() {
            query_oc = new DBGenericQueriesUtil<OrdenCompra>(context, context.ordenes_compra);
            qeoc = new DBGenericQueriesUtil<EntregaOC>(context, context.entregas_oc);
            qeocl = new DBGenericQueriesUtil<EOCLinea>(context , context.entrega_oc_linea);
        }

        internal void insertar_linea(int id_eoc, int id_productoa, int cantidada)
        {
            //codigo para insetar la linea de Entrega
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
        
    }
}