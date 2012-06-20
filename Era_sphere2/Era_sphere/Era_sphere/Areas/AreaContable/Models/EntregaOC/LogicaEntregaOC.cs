using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LogicaEntregaOC
    {
        EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<EntregaOC> qeoc;
        DBGenericQueriesUtil<EOCLinea> qeocl;



        internal void insertar_linea(int id_eoc, int id_productoa, int cantidada)
        {
            //codigo para insetar la linea de Entrega
        }

    }
}