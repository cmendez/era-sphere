using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public class LogicaAmbiente : InterfazLogicaAmbiente
    {
        public EraSphereContext context = new EraSphereContext();
        public EraSphereContext context_publico { get { return context; } }
        DBGenericQueriesUtil<Ambiente> database_table;

        public LogicaAmbiente()
        {
            database_table = new DBGenericQueriesUtil<Ambiente>(context, context.ambientes);
        }

        public List<AmbienteView> retornarAmbientes()
        {
            List<Ambiente> ambientes = database_table.retornarTodos();
            List<AmbienteView> ambientes_view = new List<AmbienteView>();

            foreach (Ambiente ambiente in ambientes) ambientes_view.Add(new AmbienteView(ambiente));
            return ambientes_view;
        }

        public List<AmbienteView> retornarAmbientes(int hotelID)
        {
            List<Ambiente> ambientes = database_table.retornarTodos().Where(p => p.piso.hotelID == hotelID).ToList();
            List<AmbienteView> ambientes_view = new List<AmbienteView>();
            foreach (Ambiente ambiente in ambientes) ambientes_view.Add(new AmbienteView(ambiente));
            return ambientes_view;
        }

        public AmbienteView retornarAmbiente(int ambienteID)
        {
            Ambiente ambiente_aux=database_table.retornarUnSoloElemento(ambienteID);
            AmbienteView ambiente = new AmbienteView(ambiente_aux);
            return ambiente;
        }

        public void modificarAmbiente(AmbienteView ambiente_view)
        {
            Ambiente ambiente = ambiente_view.deserializa(this);
            return;
        }

        public void agregarAmbiente(AmbienteView ambiente)
        {
            database_table.agregarElemento(ambiente.deserializa(this));
        }

        public void eliminarAmbiente(int ambienteID)
        {
            database_table.eliminarElemento(ambienteID);
        }

        public List<Ambiente> buscarAmbiente(Ambiente ambiente_campos)
        {
            return database_table.buscarElementos(ambiente_campos);
        }
    }
}