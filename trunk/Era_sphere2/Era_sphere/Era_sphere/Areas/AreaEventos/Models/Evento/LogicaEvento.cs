using System.Collections.Generic;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;

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
            IEnumerable<Evento> eventos = database_table.retornarTodos();//Where( p => p.piso.hotel.ID == id_hotel );
            List<EventoView> evento_view = new List<EventoView>();

            foreach (Evento evento in eventos) evento_view.Add(new EventoView(evento));
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

        public void agregarAmbienteAEvento(int idEvento, EventoXAmbienteView exaview)
        {
            //EventoXAmbiente.EventoXAmbiente exa = new EventoXAmbiente.EventoXAmbiente();
            exaview.eventoID = idEvento;
            LogicaEventoXAmbiente logicaEAX = new LogicaEventoXAmbiente();
            logicaEAX.agregarElemento(exaview);

            //IEnumerable<EventoXAmbiente.EventoXAmbiente> ans = from ambiente in context.p_x_p
            //                                        where ambiente.ambienteID == exaview.productoID && producto.proveedorID == id
            //                                        select ambiente;
            //List<proveedor_x_producto> ret = ans.ToList();
            //if (ret.Count != 0)
            //{
            //    ppv.ID = ret.ElementAt(0).ID;
            //    modificar_producto(id, ppv);
            //    return;
            //}


            //pp.precio_unitario = ppv.precio_unitario;
            //pp.proveedor = context.proveedores.Find(id);
            //pp.producto = context.productos.Find(ppv.productoID);
            //DBGenericQueriesUtil<proveedor_x_producto> query = new DBGenericQueriesUtil<proveedor_x_producto>(context, context.p_x_p);
            //query.agregarElemento(pp);
        }
    }
}