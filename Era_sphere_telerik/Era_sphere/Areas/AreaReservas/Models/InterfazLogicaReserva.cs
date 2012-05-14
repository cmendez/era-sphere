using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public interface InterfazLogicaReserva
    {
        List<Reserva> retornarReservas();
        Reserva retornarReserva(int reserva_id);
        void modificarReserva(Reserva reserva); //anular reserva se encuentra contemplada en este punto
        void registrarReserva(Reserva reserva);
        void eliminarReserva(int reserva_id);
        List<Reserva> buscarReserva(Reserva reserva);
        //puedo buscar una reserva según clientes
        List<Reserva> buscarReserva(Cliente cliente);
        //falta agregar más funciones especificas para interactuar con clientes, pagos, comodidades, habitaciones    
    }
}