using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class LogicaRecibo
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Recibo> database_table;

        public LogicaRecibo()
        {   
            database_table = new DBGenericQueriesUtil< Recibo >(context, context.recibos);
        }
        public int nuevoRecibo()
        {
            Recibo rec = new Recibo();
            database_table.agregarElemento(rec);
            return rec.ID;
        }
    }
}