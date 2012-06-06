using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEventos.Models.Participante;

namespace Era_sphere.Areas.AreaEventos.Models.Participante
{
    public class LogicaParticipante
    {
        Era_sphere.Generics.EraSphereContext participante_context = new Era_sphere.Generics.EraSphereContext();
        DBGenericQueriesUtil<Participante> database_table;

        public LogicaParticipante()
        {
            database_table = new DBGenericQueriesUtil<Participante>(participante_context, participante_context.participantes);
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

        public List<Participante> retornarParticipantes(int evento_id)
        {
            return database_table.retornarTodos().Where(p => p.eventoID == evento_id).ToList();
        }

        public List< ParticipanteView > retornarParticipanteView(int evento_id)
        {
            List<ParticipanteView> participante_view = new List<ParticipanteView>();
            var participantes = database_table.retornarTodos().Where(p => p.eventoID == evento_id);
            foreach (Participante participante in participantes) participante_view.Add(new ParticipanteView(participante));
            return participante_view;
        }

        public ParticipanteView retornarParticipante(int participante_id)
        {
            Participante participante= database_table.retornarUnSoloElemento(participante_id);
            ParticipanteView participante_view = new ParticipanteView(participante);
            return participante_view;
        }

        public Participante retornarObjParticipante(int participante_id)
        {
            return database_table.retornarUnSoloElemento(participante_id);
        }

        public void modificarParticipante(ParticipanteView participante_view)
        {

            Participante participante= participante_view.deserializa();
            database_table.modificarElemento(participante, participante.ID);
            return;
        }

        public void agregarParticipante(ParticipanteView participante)
        {
            database_table.agregarElemento(participante.deserializa());
        }

        public void eliminarParticipante(int participanteID)
        {
            database_table.eliminarElemento(participanteID);
        }
        /*
        public List<TipoHabitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion_campos)
        {
            return database_table.buscarElementos(tipohabitacion_campos);
        }*/



    }
}