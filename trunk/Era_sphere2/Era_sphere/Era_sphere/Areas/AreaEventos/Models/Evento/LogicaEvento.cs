using System.Collections.Generic;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;
using System;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class LogicaEvento
    {
        EraSphereContext evento_context = new EraSphereContext();
        DBGenericQueriesUtil<Evento> database_table;
        
        public LogicaEvento()
        {   
            database_table = new DBGenericQueriesUtil< Evento >(evento_context, evento_context.eventos);
            
        }

        public List<EventoView> retornarEventos( int id_hotel )
        {
            IEnumerable<Evento> eventos = database_table.retornarTodos();
            

            List<EventoView> evento_view = new List<EventoView>();

            foreach (Evento evento in eventos) 
                if(evento.hotel==id_hotel)
                    evento_view.Add(new EventoView(evento));
            return evento_view;
        }

        public EventoView retornarEvento(int evento_id)
        {
            Evento evento = database_table.retornarUnSoloElemento(evento_id);
            EventoView evento_view = new EventoView(evento);
            return evento_view;
        }

        public Evento retornarObjEvento(int evento_id)
        {
            return database_table.retornarUnSoloElemento(evento_id);
        }
        public void modificarEvento(EventoView evento_view)
        {
            Evento modif = evento_view.deserializa();  
            database_table.modificarElemento(modif, modif.ID);
            return;
        }

        public void agregarEvento(EventoView evento)
        {
            Evento evento_per = evento.deserializa();
            //habitacion_per.tipoHabitacion = habitacion_context.tipos_habitacion.Find(habitacion_per.tipoHabitacionID);
            //habitacion_per.estado = habitacion_context.estado_espacio_rentable.Find(habitacion.estado_habitacionID);
            //habitacion_per.piso = habitacion_context.pisos.Find(habitacion.pisoID);
            database_table.agregarElemento(evento_per);
        }

        public void eliminarEvento(int habitacion_id)
        {
            database_table.eliminarElemento(habitacion_id);
        }

        /*public List<Habitacion> buscarHabitacion(Habitacion habitacion_campos)
        {
            return database_table.buscarElementos(habitacion_campos);
        }*/

        public List<AmbienteView> ambientesRestantes(int idHotel, int idEvento)
        {

            List<Ambiente> usados = new List<Ambiente>();
            //List<Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente> relacion = (evento_context.eventos.Find(idEvento).eventoXAmbiente).;
            //foreach (Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente exa in relacion) usados.Add(proveedor_context.productos.Find(pp.productoID));
            //List<Producto> resta;
            //if (text != null)
            //    resta = proveedor_context.productos.Where(p => p.descripcion.StartsWith(text)).ToList();
            //else
            //    resta = proveedor_context.productos.ToList();
            //foreach (var p in usados) resta.Remove(p);
            //List<ProductoView> ans = new List<ProductoView>();
            //foreach (var p in resta) ans.Add(new ProductoView(p));
            
            LogicaAmbiente logicaAmbiente=new LogicaAmbiente();

            return logicaAmbiente.retornarAmbientes(idHotel);
        }

        public List<AmbienteView> retornarAmbientes(int idEvento)
        {
            LogicaEventoXAmbiente lexa=new LogicaEventoXAmbiente();
            List<EventoXAmbienteView> exalist=lexa.retornarAmbientes(idEvento);
            List <AmbienteView> ambientes_view=new List<AmbienteView> ();
            LogicaAmbiente logicaAmbiente= new LogicaAmbiente();
            foreach (EventoXAmbienteView eav in exalist)
            {
                ambientes_view.Add(logicaAmbiente.retornarAmbiente(eav.ambienteID));
            }
            return ambientes_view;
            //ICollection<Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente> aux=evento_context.eventos.Find(idEvento).eventoXAmbiente;

            
        }

        public void eliminarAmbiente(int idEvento, EventoXAmbienteView ambiente)
        {

            EventoXAmbiente.EventoXAmbiente exa = evento_context.eventoXAmbientes.Find(ambiente.ID);
            evento_context.eventoXAmbientes.Remove(exa);
            evento_context.SaveChanges();
        
        }

        public  void modificarAmbiente(int idEvento, EventoXAmbienteView ambiente)
        {

            EventoXAmbiente.EventoXAmbiente exa = evento_context.eventoXAmbientes.Find(ambiente.ID);
            exa.precio = ambiente.precio;
            DBGenericQueriesUtil<EventoXAmbiente.EventoXAmbiente> query = new DBGenericQueriesUtil<EventoXAmbiente.EventoXAmbiente>(evento_context, evento_context.eventoXAmbientes);
            query.modificarElemento(exa, exa.ID);
        }

        public void agregarAmbienteAEvento(int idEvento, EventoXAmbienteView exaview,int idAmbiente)
        {
            EventoXAmbiente.EventoXAmbiente exa = new EventoXAmbiente.EventoXAmbiente();
            //exaview.eventoID = idEvento;
            LogicaEventoXAmbiente logicaEAX = new LogicaEventoXAmbiente();
            exa.precio = exaview.precio;
            exa.fecha_hora_inicio = exaview.fecha_hora_inicio;
            exa.fecha_hora_fin = exaview.fecha_hora_fin;
            exa.ambiente = evento_context.ambientes.Find(idAmbiente);
            exa.evento = evento_context.eventos.Find(idEvento);
            //pp.producto = context.productos.Find(ppv.productoID);
            DBGenericQueriesUtil<EventoXAmbiente.EventoXAmbiente> query = new DBGenericQueriesUtil<EventoXAmbiente.EventoXAmbiente>(evento_context, evento_context.eventoXAmbientes);
            query.agregarElemento(exa);
        }

        public  void modificarEvento(int idEvento, decimal costo,int participantes)
        {
            
            Evento evento = evento_context.eventos.Find(idEvento);
            evento.precio_total = costo;
            evento.num_participantes = participantes;
            DBGenericQueriesUtil<Evento> query = new DBGenericQueriesUtil<Evento>(evento_context, evento_context.eventos);
            query.modificarElemento(evento, evento.ID);

        }
    }
}