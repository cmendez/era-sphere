using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class LogicaMoneda : InterfazLogicaMoneda
    {
        EraSphereContext moneda_context = new EraSphereContext();
        DBGenericQueriesUtil<Moneda> database_table;

        public LogicaMoneda()
        {
            database_table = new DBGenericQueriesUtil<Moneda>(moneda_context, moneda_context.monedas);
        }
        public void agregarMoneda(MonedaView moneda)
        {
            database_table.agregarElemento(moneda.deserializa(this));
        }
        public void modificarMoneda(MonedaView moneda_view)
        {
            Moneda moneda = moneda_view.deserializa(this);
            database_table.modificarElemento(moneda, moneda.ID);
            return;
        }
        public void eliminarMoneda(int moneda_id)
        {
            database_table.eliminarElemento(moneda_id);
            return;
        }
        public List<MonedaView> retornarMonedas()
        {
            List<Moneda> monedas = database_table.retornarTodos();
            List<MonedaView> monedas_view = new List<MonedaView>();

            foreach (Moneda moneda in monedas) monedas_view.Add(new MonedaView(moneda));
            return monedas_view;
        }
        public MonedaView retornarMoneda(int moneda_id)
        {
            Moneda moneda = database_table.retornarUnSoloElemento(moneda_id);
            MonedaView moneda_view = new MonedaView(moneda);
            return moneda_view;
        }

        public List<Moneda> retornarMonedas2()
        {
            return moneda_context.monedas.ToList();
        }
    }
}