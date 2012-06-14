using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaReservas.Models;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class LogicaCliente : InterfazLogicaCliente
    {
        public EraSphereContext cliente_context=new EraSphereContext();
        DBGenericQueriesUtil<Cliente> database_table;

        public LogicaCliente()
        {
            database_table = new DBGenericQueriesUtil<Cliente>(cliente_context, cliente_context.clientes);
        }

        public List<Cliente> retornarClientes()
        {
            
            List<Cliente> clientes = database_table.retornarTodos();
            return clientes;
        }

        public Cliente retornarCliente(int id_cliente)
        {
            Cliente cliente = database_table.retornarUnSoloElemento(id_cliente);
            return cliente;
        }

        public void modificarCliente(Cliente cliente)
        {
            database_table.modificarElemento(cliente, cliente.ID);
        }


        
        public void agregarCliente(Cliente cliente)
        {
            //if (cliente_context.clientes.Where(c => (c.documento_identidad == cliente.documento_identidad) && (c.tipo_documentoID == cliente.tipo_documentoID)).Count() > 0)
            //{
               
            //    //llamar a una alerta ;)
            //    int a = 2;
            //}
            //else
                database_table.agregarElemento(cliente);
        }

        public void eliminarCliente(int cliente_id)
        {
            database_table.eliminarElemento_logico(cliente_id);
        }

        public List<Cliente> buscarCliente(Cliente cliente_campos)
        {
            return database_table.buscarElementos(cliente_campos);
        }

        public List<ClienteNaturalView> retonarClientesNaturales()
        {
            List<Cliente> clientes = database_table.retornarTodos().Where(c => c.tipoID == 1).ToList();
            List<ClienteNaturalView> clientes_view = new List<ClienteNaturalView>();

            foreach (Cliente cliente in clientes) clientes_view.Add(new ClienteNaturalView(cliente));
            return clientes_view;
        }
        
        public List<ClienteJuridicoView> retonarClientesJuridicos()
        {
            List<Cliente> clientes = database_table.retornarTodos().Where(c => c.tipoID == 2).ToList();
            List<ClienteJuridicoView> clientes_view = new List<ClienteJuridicoView>();

            foreach (Cliente cliente in clientes) clientes_view.Add(new ClienteJuridicoView(cliente));
            return clientes_view;
        }

        //Metodo para autocompletar ;)
        public List<string> retornarClientesFiltro(String cadena_nombre)
        {
            List<Cliente> clientes = database_table.retornarTodos();

            //:_:
            List<string> clientes_vista = new List<string>();
            
            foreach (Cliente cliente in clientes)
            {
                if ((cliente.tipoID == 1) && ( (cliente.nombre.ToUpper().Contains(cadena_nombre.ToUpper())) || (cliente.apellido_paterno.ToUpper().Contains(cadena_nombre.ToUpper())) ||
                    (cliente.apellido_materno.ToUpper().Contains(cadena_nombre.ToUpper()))))
                {
                    clientes_vista.Add(toString(cliente));
                }
                if ((cliente.tipoID == 2) && cliente.razon_social.ToUpper().Contains(cadena_nombre.ToUpper()))
                {
                    clientes_vista.Add(toString(cliente));
                }
            }
            
            return clientes_vista;
        }

        public static string toString(Cliente cliente)
        {
            string res;
            if (cliente.tipoID == 1)
            {
                res = cliente.nombre + " " + cliente.apellido_paterno + " " + cliente.apellido_materno + ", "
                      + cliente.tipo_documento.descripcion + ": " + cliente.documento_identidad;
            }
            else res = cliente.razon_social + ", RUC: " + cliente.ruc;
            return res;
        }


        public void cambiarEstadoCliente(Reserva reserva)
        {
            
            
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                if ((reserva.responsable_pago.ID == clientes[i].ID) && (reserva.estado.ID == 1))
                {
                    clientes[i].estadoID = 2;
                    clientes[i].estado = cliente_context.estados_cliente.Find(2);
                    modificarCliente(clientes[i]);
                    break;
                }

            }
        }

        public void cambiarEstadoCheckIn(Reserva reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                
                if ((reserva.responsable_pago.ID == clientes[i].ID) && (reserva.estado.ID == 2))
                {
                    clientes[i].estadoID = 3;
                    clientes[i].estado = cliente_context.estados_cliente.Find(3);
                    modificarCliente(clientes[i]);
                    break;
                }
             }
        }


        public void cambiarEstadoCheckOut(Reserva reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                if ((reserva.responsable_pago.ID == clientes[i].ID) && ((reserva.estado.ID == 3) || (reserva.estado.ID == 4)))
                {

                    // falta condicion para que se pueda determinar si se debe cambiar a sin reserva o con reserva
                    clientes[i].estadoID = 1;
                    clientes[i].estado = cliente_context.estados_cliente.Find(1);
                    modificarCliente(clientes[i]);
                    break;
                }
            }
        }


        public void cambiarEstadoEliminarReserva(int id_cliente_reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                if (id_cliente_reserva == clientes[i].ID)
                {

                    if (clientes[i].reservas.Count()==0)
                    {
                        clientes[i].estadoID = 1;
                        clientes[i].estado = cliente_context.estados_cliente.Find(1);
                        modificarCliente(clientes[i]);
                        break;
                    }
                }
            }
        }

        public void cambiarEstadoAnularReserva(int id_cliente_reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                if (id_cliente_reserva == clientes[i].ID)
                {

                    if (clientes[i].reservas.Where(x => x.estado.descripcion != "Anulada").ToList().Count() == 0)
                    {
                        clientes[i].estadoID = 1;
                        clientes[i].estado = cliente_context.estados_cliente.Find(1);
                        modificarCliente(clientes[i]);
                        break;
                    }
                }
            }
        }

        //para asignar una habitación a un cliente
        public void asignarHabitacionCliente(Reserva reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();
            

        }



  


    }
}