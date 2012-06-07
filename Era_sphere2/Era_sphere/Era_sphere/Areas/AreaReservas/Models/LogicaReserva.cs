using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;


namespace Era_sphere.Areas.AreaReservas.Models
{
    public class LogicaReserva
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Reserva> tabla_reserva;

        public LogicaReserva()
        {
            tabla_reserva = new DBGenericQueriesUtil<Reserva>(context, context.Reservas);
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
        }

        public void eliminarReserva(int reserva_id)
        {
            tabla_reserva.eliminarElemento(reserva_id);
        }

        public List<Reserva> buscarReserva(Reserva reserva)
        {
            return tabla_reserva.buscarElementos(reserva);
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
            var query = from u in context.habitacion_x_reservas
                        where u.reservaID == reservaID
                        select context.habitaciones.Find(u.habitacionID);
            return query.ToList();
        }
    }
}
        