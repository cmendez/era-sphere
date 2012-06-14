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
        }
        public int hallaIDCruce(Reserva r, Habitacion h)
        {
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
            List<HabitacionXReserva> a_eliminar = new List<HabitacionXReserva>();
            foreach (var x in habitaciones)
                if (!hab_ids.Contains(x.habitacionID)) a_eliminar.Add(x);
            foreach (var x in a_eliminar) tabla_habitacion_x_reserva.eliminarElemento(x.ID);

            foreach (var id in hab_ids)
            {
                bool dentro = false;
                foreach (var x in habitaciones) if (x.habitacionID == id) dentro = true;
                if (!dentro) agregaRelacion(r, context.habitaciones.Find(id));
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
                monto += 100;
                    //habitacion.tipoHabitacion.costo_base;
            }

            //tenemos el costo base de las habitaciones, ahora determinar si se anhadió comodidades
            /* EDIT: ahora parece que no hay mas comodidades
            for (int i = 0; i < reserva.lista_habitaciones_reservadas.Count(); i++)
            {
                HabitacionXReserva habi =  reserva.lista_habitaciones_reservadas.ElementAt(i);
                monto += 0; //reserva.lista_comodidades.ElementAt(i).
            }

            */
            return monto;
                
        }



        public decimal calcularDiasEstadia(Reserva reserva)
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


        public void asignacion_habitaciones_reservadas(Reserva reserva)
        {
           /* for (int i = 0; i < reserva.lista_habitaciones.Count(); i++)
            {
                if (reserva.lista_habitaciones.ElementAt(i).estado.descripcion == "clicked")
                {
                    reserva.lista_habitaciones_reservadas.Add(reserva.lista_habitaciones.ElementAt(i));
                }
            }*/
        
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
            var query = from u in context.habitacion_x_reserva
                        where u.reservaID == reservaID
                        select context.habitaciones.Find(u.habitacionID);
            return query.ToList();
        }


        //cambios de estados propios de la reserva

        public void cambiarEstadoReservaAnular(Reserva reserva)
        {
                    reserva.estadoID = 4;
                    reserva.estado = context.estados_reserva.Find(4);
                    modificarReserva(reserva);
                    LogicaCadena cadena_context = new LogicaCadena();
                    Cadena cadena = cadena_context.retornarCadena(1);

                    if (DateTime.Now.Subtract(reserva.dia_creacion).Days < cadena.d_ant_ret)
                    {
                        ReciboLinea recibo = new ReciboLinea();
                        recibo.detalle = "Devolución de monto adelantado de reserva";
                        recibo.fecha = DateTime.Now;
                        recibo.precio_unitario = (-1)*reserva.precio_derecho_reserva;
                        recibo.unidades = 1;
                        //llamar un popup de recibo gg
                    }
            
        }


        public void cambiarEstadoReservaCheckIn(Reserva reserva)
        {
            //List<Reserva> reservas = new List<Reserva>();
            //LogicaReserva logica_reserva = new LogicaReserva();
            //reservas = logica_reserva.retornarReservas();
            //for (int i = 0; i < reservas.Count(); i++)
            //{
            //    if (reservas[i].ID == reserva.ID)
            //    {
            reserva.estadoID = 2;
            reserva.estado = context.estados_reserva.Find(2);
            modificarReserva(reserva);
            //    }
            //}

        }

        public void cambiarEstadoCheckOut(Reserva reserva)
        {
            //List<Reserva> reservas = new List<Reserva>();
            //LogicaReserva logica_reserva = new LogicaReserva();
            //reservas = logica_reserva.retornarReservas();
            //for (int i = 0; i < reservas.Count(); i++)
            //{
            //    if (reservas[i].ID == reserva.ID)
            //    {
            reserva.estadoID = 3;
            reserva.estado = context.estados_reserva.Find(3);
            modificarReserva(reserva);
            //    }
            //}

        }



        public List<ServicioView> getServicios(int reserva_id)
        {
            List<ServicioXReserva> cruce = context.servicioxreservas.Where(x => x.reservaID == reserva_id).ToList();
            List<ServicioView> res = new List<ServicioView>();
            foreach(var s in cruce) 
                res.Add(new ServicioView(context.servicios.Find(s.servicioID)));
            return res;
        }

        public void agregaServicio(int reserva_id, Servicio s)
        {
            tabla_servicio_x_reserva.agregarElemento(new ServicioXReserva { reservaID = reserva_id, servicioID = s.ID });
        }
        public void anularServicio(int servicio_id)
        {
            Servicio s = context.servicios.Find(servicio_id);
            s.eliminado = true;
            //FALTA
        }
    }
}
        