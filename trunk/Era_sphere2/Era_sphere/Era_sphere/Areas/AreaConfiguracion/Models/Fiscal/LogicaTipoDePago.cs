using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class LogicaTipoDePago : InterfazLogicaTipoDePago
    {
        EraSphereContext tipodepago_context = new EraSphereContext();
        DBGenericQueriesUtil<TipoDePago> database_table;

        public LogicaTipoDePago()
        {
            database_table = new DBGenericQueriesUtil<TipoDePago>(tipodepago_context, tipodepago_context.tiposdepagos);
        }
        public void agregarTipoDePago(TipoDePagoView tipodepago)
        {
            database_table.agregarElemento(tipodepago.deserializa(this));
        }
        public void modificarTipoDePago(TipoDePagoView tipodepago_view)
        {
            TipoDePago tipodepago = tipodepago_view.deserializa(this);
            database_table.modificarElemento(tipodepago, tipodepago.ID);
            return;
        }
        public void eliminarTipoDePago(int tipodepago_id)
        {
            database_table.eliminarElemento(tipodepago_id);
            return;
        }
        public List<TipoDePagoView> retornarTiposDePagos()
        {
            List<TipoDePago> tiposdepagos = database_table.retornarTodos();
            List<TipoDePagoView> tiposdepagos_view = new List<TipoDePagoView>();

            foreach (TipoDePago tipodepago in tiposdepagos) tiposdepagos_view.Add(new TipoDePagoView(tipodepago));
            return tiposdepagos_view;
        }

        public TipoDePagoView retornarTipoDePago(int tipodepago_id)
        {
            TipoDePago tipodepago = database_table.retornarUnSoloElemento(tipodepago_id);
            TipoDePagoView tipodepago_view = new TipoDePagoView(tipodepago);
            return tipodepago_view;
        }
    }
}