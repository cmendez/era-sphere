using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Areas.AreaEventos.Models.Adicionales
{
    public class LogicaAdicional
    {
        Era_sphere.Generics.EraSphereContext adicional_context = new Era_sphere.Generics.EraSphereContext();
        DBGenericQueriesUtil<Adicional> database_table;
        
        public LogicaAdicional()
        {   
            database_table = new DBGenericQueriesUtil< Adicional >(adicional_context, adicional_context.adicionales);
        }

        /*
        public List<AdicionalView> retornarAdicionales()
        {
            List<Adicional> tipoHabitaciones = database_table.retornarTodos();
            List<> tipoHabitacion_view = new List<TipoHabitacionView>();

            foreach (TipoHabitacion tipoHabitacion in tipoHabitaciones) tipoHabitacion_view.Add(new TipoHabitacionView(tipoHabitacion));
            return tipoHabitacion_view;
        }
         */
        
        public List<Adicional> retornarAdicionales(int evento_id)
        {
            return database_table.retornarTodos().Where(p => p.eventoID == evento_id).ToList();
        }

        public List<AdicionalView> retornarAdicionalesView(int evento_id)
        {
            List<AdicionalView> adicional_view= new List<AdicionalView>();
            var adicionales= database_table.retornarTodos().Where(p=>p.eventoID==evento_id);
            foreach (Adicional adicional in adicionales) adicional_view.Add(new AdicionalView(adicional));
            return adicional_view;
        }

        public AdicionalView retornarAdicional(int adicional_id)
        {
            Adicional adicional= database_table.retornarUnSoloElemento(adicional_id);
            AdicionalView adicional_view = new AdicionalView(adicional);
            return adicional_view;
        }

        

        public Adicional retornarObjAdicional(int adicional_id)
        {
            return database_table.retornarUnSoloElemento(adicional_id);
        }

        public void modificarAdicional(AdicionalView adicional_view)
        {
            
            Adicional adicional = adicional_view.deserializa();
            database_table.modificarElemento(adicional, adicional.ID);
            return;
        }

        public void agregarAdicional(AdicionalView adicional)
        {
            database_table.agregarElemento(adicional.deserializa());
        }

        public void eliminarAdicional(int adicionalID)
        {
            database_table.eliminarElemento(adicionalID);
        }
        /*
        public List<TipoHabitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion_campos)
        {
            return database_table.buscarElementos(tipohabitacion_campos);
        }*/






        public decimal RetornarCosto(int idEvento)
        {
            decimal costo = 0;
            List<Adicional> adicionales = retornarAdicionales(idEvento);
            foreach (Adicional adicional in adicionales) costo += adicional.precio;
            return costo;
        }
    }
}