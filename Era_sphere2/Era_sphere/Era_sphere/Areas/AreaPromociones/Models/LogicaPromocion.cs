using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaPromociones.Models
{
    public class LogicaPromocion:InterfazLogicaPromocion
    {
        public EraSphereContext promocion_context = new EraSphereContext();
        DBGenericQueriesUtil<Promocion> database_table;
        
        public LogicaPromocion()
        {
            database_table = new DBGenericQueriesUtil<Promocion>(promocion_context, promocion_context.promociones);
        }

        public List<Promocion> retornarpromociones(int puntos) {
            List<Promocion> r = new List<Promocion>();

            foreach (Promocion p in promocion_context.promociones) 
            {
                if (p.puntos_requeridos <= puntos) { 
                    r.Add(p);
                }
            }
            return r;
        }
        

        public List<PromocionView> retornarPromociones()
        {
            List<Promocion> promociones = database_table.retornarTodos();
            List<PromocionView> promociones_view = new List<PromocionView>();

            foreach (Promocion promocion in promociones) promociones_view.Add(new PromocionView(promocion));
            return promociones_view;
        }

        public PromocionView retornarPromocion(int promocionID)
        {
            Promocion promocion_aux = database_table.retornarUnSoloElemento(promocionID);
            PromocionView promocion = new PromocionView(promocion_aux);
            return promocion;
        }

        public void modificarPromocion(PromocionView promocion_view)
        {
            Promocion promocion = promocion_view.deserializa(this);
            //Promocion orig = database_table.retornarUnSoloElemento(promocion_view.ID);
            //orig.nombre = promocion.nombre ?? orig.nombre;
            database_table.modificarElemento(promocion, promocion.ID);
        }

        public void agregarPromocion(PromocionView promocion)
        {
            database_table.agregarElemento(promocion.deserializa(this));
        }

        public void eliminarPromocion(int promocionID)
        {
            database_table.eliminarElemento(promocionID);
        }

        public List<Promocion> buscarPromocion(Promocion promocion_campos)
        {
            return database_table.buscarElementos(promocion_campos);
        }

    }
}