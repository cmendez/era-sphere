using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaTipoDePago:InterfazLogicaTipoDePago
    {
        TipoDePagoContext proveedor_context = new TipoDePagoContext();
        DBGenericQueriesUtil<PagoTarjeta> table_Tarjeta;

        public LogicaTipoDePago()
        {
            table_Tarjeta = new DBGenericQueriesUtil<PagoTarjeta>(proveedor_context, proveedor_context.tarjetas);
        }

        public List<PagoTarjeta> retornarTarjetaPagos()
        {
            return table_Tarjeta.retornarTodos();
        }

        public PagoTarjeta retornarTarjetaPago(int idpagotarjeta)
        {
            return table_Tarjeta.retornarUnSoloElemento(idpagotarjeta);
        }

        public void ModificarTarjetaPago(PagoTarjeta tarjeta)
        {
            int id = tarjeta.ID;
            table_Tarjeta.modificarElemento(tarjeta, id);
        }

        public void agregarTarjetaPago(PagoTarjeta tarjeta)
        {
            table_Tarjeta.agregarElemento(tarjeta);
        }

        public void eliminarTarjetaPago(int idpagotarjeta)
        {
            table_Tarjeta.eliminarElemento(idpagotarjeta);
        }

        public List<PagoTarjeta> buscarTarjetaPago(PagoTarjeta tarjeta)
        {
            return table_Tarjeta.buscarElementos(tarjeta);
        }
    }
}