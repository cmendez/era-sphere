using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaMoneda:InterfazLogicaMoneda
    {
        MonedaContext moneda_context = new MonedaContext();

        DBGenericQueriesUtil<Moneda> table_moneda;
        DBGenericQueriesUtil<Pais> table_pais;

        public LogicaMoneda()
        {
            table_moneda = new DBGenericQueriesUtil<Moneda>(moneda_context, moneda_context.monedas);
            table_pais = new DBGenericQueriesUtil<Pais>(moneda_context, moneda_context.pais);
        }

        public List<Moneda> RetornarMonedas()
        {   
            return table_moneda.retornarTodos();
        }

        public Moneda retornarMoneda(int idmoneda)
        {
            return table_moneda.retornarUnSoloElemento(idmoneda);
        }

        public Pais retornarPais(int idmoneda)
        {
            return table_pais.retornarUnSoloElemento(idmoneda);
        }

        public void modificarMoneda(Moneda moneda)
        {
            int id = moneda.idPais;
            moneda.pais = retornarPais(id);
            table_moneda.modificarElemento(moneda, moneda.ID);
        }

        public void agregarMoneda(Moneda moneda)
        {
            int id = moneda.idPais;
            moneda.pais = retornarPais(id);
            table_moneda.agregarElemento(moneda);
        }

        public void eliminarMoneda(int idmoneda)
        {
            table_moneda.eliminarElemento(idmoneda);
        }

        public List<Moneda> buscarMoneda(Pais idpais) 
        {
            Moneda m=new Moneda();
            m.idPais = idpais.ID;
            return table_moneda.buscarElementos(m);
        }


    }
}