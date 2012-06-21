using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaReservas.Models.Consultas;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaHoteles.Controllers;


namespace Era_sphere.Areas.AreaReservas.Models
{
    public class LogicaReserva
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Reserva> tabla_reserva;
        DBGenericQueriesUtil<HabitacionXReserva> tabla_habitacion_x_reserva;
        DBGenericQueriesUtil<ServicioXReserva> tabla_servicio_x_reserva;

        public LogicaReserva()
        {
            tabla_reserva = new DBGenericQueriesUtil<Reserva>(context, context.Reservas);
            tabla_habitacion_x_reserva = new DBGenericQueriesUtil<HabitacionXReserva>(context, context.habitacion_x_reserva);
            tabla_servicio_x_reserva = new DBGenericQueriesUtil<ServicioXReserva>(context, context.servicioxreservas);
        }
        public int hallaIDCruce(Reserva r, Habitacion h)
        {
            var todos = context.habitacion_x_reserva.ToList();
            return context.habitacion_x_reserva.FirstOrDefault(x => x.habitacionID == h.ID && x.reservaID == r.ID).ID;
        }
        


        public List<ConsultaLineaView> getHabitaciones(int reserva_id)
        {
            List<int> hxr = context.habitacion_x_reserva.Where(x => x.reservaID == reserva_id).Select(x => x.habitacionID).ToList();
            List<ConsultaLineaView> res = new List<ConsultaLineaView>();
            foreach(int hid in hxr){
                Habitacion h = context.habitaciones.Find(hid);
                res.Add(new ConsultaLineaView { habitacionID = hid, numero_habitacion = h.detalle, tipo_habitacionID = h.tipoHabitacionID });
            }
            return res;
        }
        public void agregaRelacion(Reserva r, Habitacion h)
        {
            tabla_habitacion_x_reserva.agregarElemento(new HabitacionXReserva(r.ID, h.ID));
            List<HabitacionXReserva> aux = context.habitacion_x_reserva.ToList();
        }
        public void refrescaHabitaciones(List<int> hab_ids, int reserva_id)
        {
            Reserva r = context.Reservas.Find(reserva_id);
            List<HabitacionXReserva> habitaciones = context.habitacion_x_reserva.Where(x => x.reservaID == reserva_id).ToList();
            HotelXTipoHabitacionXTemporadaController aux = new HotelXTipoHabitacionXTemporadaController();
            foreach (var id in hab_ids)
            {
                Habitacion h = context.habitaciones.Find(id);
                agregaRelacion(r, h);
                r.registraReciboLinea(new AreaContable.Models.Recibo.ReciboLinea("   " + "Habitacion " + h.detalle,
                              new TipoHabitacionView(h.tipoHabitacion, r.hotelID).costo , 1, DateTime.Now, false, r.dias_estadia));
            }
        }

        //inicio métodos básicos
        public List<Reserva> retornarReservas()
        {
            return tabla_reserva.retornarTodos();
        }

        public Reserva retornarReserva(int reserva_id)
        {
            return tabla_reserva.retornarUnSoloElemento(reserva_id);
        }

        public void modificarReserva(Reserva reserva) //anular reserva se encuentra contemplada en este punto
        {
            tabla_reserva.modificarElemento(reserva,reserva.ID);
        }


         public void registrarReserva(Reserva reserva)
        {
            tabla_reserva.agregarElemento(reserva);
            LogicaCliente logica_cliente = new LogicaCliente();
            logica_cliente.cambiarEstadoCliente(reserva);
           //incluye lista de reservas
            reserva.responsable_pago.reservas.Add(reserva);
            reserva.generaReciboLineas();

            //reserva.responsable_pago.estadoID = 2;
            //reserva.responsable_pago.numero_reservas += 1;
        }

        public void eliminarReserva(int reserva_id)
        {
            int cliente_id = retornarReserva(reserva_id).responsable_pagoID;
            LogicaCliente logica_cliente = new LogicaCliente();
            tabla_reserva.eliminarElemento(reserva_id);
            logica_cliente.cambiarEstadoEliminarReserva(cliente_id);
        }

        public List<Reserva> buscarReserva(Reserva reserva)
        {
            return tabla_reserva.buscarElementos(reserva);
        }

        public List<ReservaView> retornarReservasHotel(int hotel_id)
        {
            List<Reserva> reservas_aux = tabla_reserva.retornarTodos().Where(p => p.hotelID == hotel_id).ToList();
            List<ReservaView> reserva_view = new List<ReservaView>();

            foreach (Reserva reserva in reservas_aux) reserva_view.Add(new ReservaView(reserva, this));
            return reserva_view;

        }


        //fin de metodos basicos


        public decimal calcularMontoInicialReserva(Reserva reserva)
        {
            decimal monto = 0;
            
            List<Habitacion> habs = this.habitacionesDeReserva(reserva.ID);

            foreach(var habitacion in habs){
                monto += habitacion.tipoHabitacion.costo_base;
                    //habitacion.tipoHabitacion.costo_base;
            }

            return monto;
                
        }



        public int calcularDiasEstadia(Reserva reserva)
        {
            TimeSpan span = reserva.check_out.Value.Subtract(reserva.check_in.Value);
            int dias_transcurridos = (int)(span.TotalDays);

            return dias_transcurridos;
        }
        

        public decimal calcularMontoCancelarReserva(Reserva reserva)
        {
            LogicaCadena cadena_context = new LogicaCadena();
            Cadena cadena = cadena_context.retornarCadena(1);

            decimal monto = reserva.costo_inicial * cadena.porc_ret;
            
            return monto;
        }


        public void cacularDatosReserva(int reserva_id)
        {
            Reserva reserva = retornarReserva(reserva_id);
            reserva.dias_estadia = calcularDiasEstadia(reserva);
            reserva.costo_inicial = calcularMontoInicialReserva(reserva);
            reserva.precio_derecho_reserva = calcularMontoCancelarReserva(reserva);
        
        }

        //puedo buscar una reserva según clientes
        public List<Reserva> buscarReservaCliente(Cliente cliente)
        {
            /*var query =
            from u in reserva_context.Reservas
            where u.responsable_pago.ID == cliente.ID
            select u;

            return query.ToList();*/
            return new List<Reserva>();
        }
        //falta agregar más funciones especificas para interactuar con clientes, pagos, comodidades, habitaciones   
    
        public List<Habitacion> habitacionesDeReserva(int reservaID)
        {
            List<HabitacionXReserva> todos = context.habitacion_x_reserva.Where(x => x.reservaID == reservaID).ToList();
            List<Habitacion> res = new List<Habitacion>();
            foreach (HabitacionXReserva hid in todos)
            {
                Habitacion h = context.habitaciones.Find(hid.habitacionID);
                res.Add(h);
            }
            return res;
        }


        //cambios de estados propios de la reserva

        public void eliminarReservaCliente(int id_reserva)
        {
            Reserva reserva = retornarReserva(id_reserva);
            LogicaCliente cliente_logica = new LogicaCliente();
            Cliente cliente = cliente_logica.retornarCliente(reserva.responsable_pagoID);

            for (int i = 0; i < cliente.reservas.Count(); i++)
            {
                if (cliente.reservas.ElementAt(i).ID == id_reserva)
                    cliente.reservas.Remove(reserva);
            }
            
        }

        public void cambiarEstadoReservaAnular(Reserva reserva)
        {
                    reserva.estadoID = 4;
                    reserva.estado = context.estados_reserva.Find(4);
                    modificarReserva(reserva);
                    LogicaCadena cadena_context = new LogicaCadena();
                    Cadena cadena = cadena_context.retornarCadena(1);
                    LogicaCliente logica_cliente = new LogicaCliente();
                    
                    if (DateTime.Now.Subtract(reserva.dia_creacion).Days < cadena.d_ant_ret)
                    {
                        ReciboLinea recibo = new ReciboLinea();
                        recibo.detalle = "Devolución de monto adelantado de reserva";
                        recibo.fecha = DateTime.Now;
                        recibo.precio_final = (-1)*reserva.precio_derecho_reserva;
                        recibo.unidades = 1;
                        //llamar un popup de recibo gg
                    }
                    //ahora parece sin reserva en caso sea la unica reserva que tenga
                    eliminarReservaCliente(reserva.ID);
                    logica_cliente.cambiarEstadoAnularReserva(reserva.responsable_pagoID);
            
        }


        public void cambiarEstadoReservaCheckIn(Reserva reserva)
        {
            LogicaCliente cliente_logica = new LogicaCliente();
            reserva.estadoID = 2;
            reserva.estado = context.estados_reserva.Find(2);
            modificarReserva(reserva);
            cliente_logica.cambiarEstadoCheckIn(reserva);

        }


        public void cambiarEstadoCheckOut(Reserva reserva)
        {
            LogicaCliente cliente_logica = new LogicaCliente();
            reserva.estadoID = 3;
            reserva.estado = context.estados_reserva.Find(3);
            modificarReserva(reserva);
            cliente_logica.cambiarEstadoCheckOut(reserva);
        
        }

        // newbie


        //public List<Habitacion> retornarListaHabitacionesReserva(int id_reserva)
        //{
        //    Reserva reserva = retornarReserva(id_reserva);
        //    List<Habitacion> lista = new List<Habitacion>();

        //    lista = habitacionesDeReserva(id_reserva);

            
        //    return null;
        //}

        //

        public void agregarLinea(int id_reserva, int id_habitacion, int id_cliente)
        {
            Reserva reserva = retornarReserva(id_reserva);
            Habitacion habitacion = context.habitaciones.Find(id_habitacion);

            int id_habitacion_reserva = hallaIDCruce(reserva, habitacion);
            HabitacionXReserva habitacion_reserva = tabla_habitacion_x_reserva.retornarUnSoloElemento(id_habitacion_reserva);
               asignarRelacionTriple(id_cliente, habitacion_reserva);               
        
        }
        public void eliminarLinea(int id_reserva, int id_habitacion, int id_cliente)
        {
            Reserva reserva = retornarReserva(id_reserva);
            Habitacion habitacion = context.habitaciones.Find(id_habitacion);

            int id_habitacion_reserva = hallaIDCruce(reserva, habitacion);
            HabitacionXReserva habitacion_reserva = tabla_habitacion_x_reserva.retornarUnSoloElemento(id_habitacion_reserva);
            this.eliminaRelacionTriple(id_cliente, habitacion_reserva);     
        }

        public void asignarRelacionTriple(int id_cliente, HabitacionXReserva habitacion_reserva)
        {
            Cliente cliente = context.clientes.Find(id_cliente);

            habitacion_reserva.huespedes.Add(cliente);
            tabla_habitacion_x_reserva.modificarElemento(habitacion_reserva, habitacion_reserva.ID);
        }
        public void eliminaRelacionTriple(int id_cliente, HabitacionXReserva habitacion_reserva)
        {
            Cliente cliente = context.clientes.Find(id_cliente);
            habitacion_reserva.huespedes.Remove(cliente);
            tabla_habitacion_x_reserva.modificarElemento(habitacion_reserva, habitacion_reserva.ID);
        }

        public List<HabitacionXReservaXClienteLineaView> retornarHabitacionReservaCliente(int id_reserva)
        {

            List<HabitacionXReserva> habitaciones_reserva = tabla_habitacion_x_reserva.retornarTodos().Where(c => c.reservaID == id_reserva).ToList();
            List<HabitacionXReservaXClienteLineaView> lista_lineas = new List<HabitacionXReservaXClienteLineaView>();

            for (int i = 0; i < habitaciones_reserva.Count(); i++)
            {
                for (int j = 0; j < habitaciones_reserva[i].huespedes.Count(); j++)
                {
                    lista_lineas.Add(new HabitacionXReservaXClienteLineaView(habitaciones_reserva[i].huespedes.ElementAt(j).ID, habitaciones_reserva[i].habitacionID));

                }
            }


            return lista_lineas;
        }


        public List<ServicioView> getServicios(int reserva_id)
        {
            List<ServicioXReserva> cruce = context.servicioxreservas.Where(x => x.reservaID == reserva_id).ToList();
            List<ServicioView> res = new List<ServicioView>();
            foreach(var s in cruce) 
                res.Add(new ServicioView(context.servicios.Find(s.servicioID)));
            return res;
        }

        public void agregaRelacionServicioXReserva(int reserva_id, Servicio s)
        {
            tabla_servicio_x_reserva.agregarElemento(new ServicioXReserva { reservaID = reserva_id, servicioID = s.ID });
        }
        public void eliminaRelacionServicioXReserva(int servicio_id, int reserva_id)
        {
            ServicioXReserva x = context.servicioxreservas.First(w => w.reservaID == reserva_id && w.servicioID == servicio_id);
            tabla_servicio_x_reserva.eliminarElemento(x.ID);
        }
        public void anularServicio(int servicio_id)
        {
            Servicio s = context.servicios.Find(servicio_id);
            s.eliminado = true;
            //FALTA
        }
    }
}
        