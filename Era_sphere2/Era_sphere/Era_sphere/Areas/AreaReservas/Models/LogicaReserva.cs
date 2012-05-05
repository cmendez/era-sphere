using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class LogicaReserva: InterfazLogicaReserva
    {
        ReservaContext reserva_context = new ReservaContext();
        DBGenericQueriesUtil<Reserva> database_table;

        public LogicaReserva()
        {
            database_table = new DBGenericQueriesUtil<Reserva>(reserva_context, reserva_context.Reservas);
        }

        public List<Reserva> retornarReservas()
        {
            return database_table.retornarTodos();
        }

        public Reserva retornarReserva(int reserva_id)
        {
            return database_table.retornarUnSoloElemento(reserva_id);
        }

        public void modificarReserva(Reserva reserva) //anular reserva se encuentra contemplada en este punto
        {
            database_table.modificarElemento(reserva,reserva.ID);
        }

        public void registrarReserva(Reserva reserva)
        {
            database_table.agregarElemento(reserva);
        }

        public void eliminarReserva(int reserva_id)
        {
            database_table.eliminarElemento(reserva_id);
        }

        public List<Reserva> buscarReserva(Reserva reserva)
        {
            return database_table.buscarElementos(reserva);
        }
        
        //puedo buscar una reserva según clientes
        public List<Reserva> buscarReserva(Cliente cliente)
        {
            var query =
            from u in reserva_context.Reservas
            where u.responsable_pago.ID == cliente.ID
            select u;

            return query.ToList();
        }
        //falta agregar más funciones especificas para interactuar con clientes, pagos, comodidades, habitaciones   
    
    }
}