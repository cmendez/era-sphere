using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaReservas.Models.Consultas;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class LogicaCliente : InterfazLogicaCliente
    {
        public EraSphereContext context=new EraSphereContext();
        DBGenericQueriesUtil<Cliente> database_table;

        public LogicaCliente()
        {
            database_table = new DBGenericQueriesUtil<Cliente>(context, context.clientes);
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
        public List<string> retornarClientesNaturalFiltro(String cadena_nombre)
        {
            List<Cliente> clientes = database_table.retornarTodos();

            //:_:
            List<string> clientes_vista = new List<string>();

            foreach (Cliente cliente in clientes)
            {
                if ((cliente.tipoID == 1) && ((cliente.nombre.ToUpper().Contains(cadena_nombre.ToUpper())) || (cliente.apellido_paterno.ToUpper().Contains(cadena_nombre.ToUpper())) ||
                    (cliente.apellido_materno.ToUpper().Contains(cadena_nombre.ToUpper()))))
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


        

        public void cambiarEstadoCheckIn(Reserva reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();

            for (int i = 0; i < clientes.Count(); i++)
            {
                
                if ((reserva.responsable_pago.ID == clientes[i].ID) && (reserva.estado.ID == 2))
                {
                    clientes[i].estadoID = 3;
                    clientes[i].estado = context.estados_cliente.Find(3);
                    modificarCliente(clientes[i]);
                    break;
                }
             }

            if (reserva.estado.ID == 2)
            {
                asignarHabitacionesHuespedesReserva(reserva);
            }
        
        
        }


        public void asignarHabitacionesHuespedesReserva(Reserva reserva)
        {
            LogicaReserva reserva_logica = new LogicaReserva();
            List<HabitacionXReserva> habitaciones_reserva = context.habitacion_x_reserva.Where(x => x.reservaID == reserva.ID).ToList();

            for (int i = 0; i < habitaciones_reserva.Count(); i++)
            {
                string habitacion = context.habitaciones.Find(habitaciones_reserva[i].habitacionID).detalle;

                for (int j = 0; j < habitaciones_reserva[i].huespedes.Count(); j++)
                {
                    habitaciones_reserva[i].huespedes.ElementAt(j).estadoID = 3;
                    habitaciones_reserva[i].huespedes.ElementAt(j).estado = context.estados_cliente.Find(3);
                    habitaciones_reserva[i].huespedes.ElementAt(j).habitacion_asignada = habitacion;
                    modificarCliente(habitaciones_reserva[i].huespedes.ElementAt(j));

                }
            }
        }



        public void DesasignarHabitacionesHuespedesReserva(Reserva reserva)
        {
            LogicaReserva reserva_logica = new LogicaReserva();
            List<HabitacionXReserva> habitaciones_reserva = context.habitacion_x_reserva.Where(x => x.reservaID == reserva.ID).ToList();

            for (int i = 0; i < habitaciones_reserva.Count(); i++)
            {
                

                for (int j = 0; j < habitaciones_reserva[i].huespedes.Count(); j++)
                {
                    cambiarEstadoCheckOutCliente(habitaciones_reserva[i].huespedes.ElementAt(j).ID, reserva);
                   

                }
            }
        }


        public void cambiarEstadoCheckOut(Reserva reserva)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = retornarClientes();
            int numero_reservas_posterior= reservasPosteriores(reserva.responsable_pagoID);
            for (int i = 0; i < clientes.Count(); i++)
            {
                if ((reserva.responsable_pago.ID == clientes[i].ID) && ((reserva.estado.ID == 3) || (reserva.estado.ID == 4)))
                {

                    if (numero_reservas_posterior == 0)
                    {
                        // falta condicion para que se pueda determinar si se debe cambiar a sin reserva o con reserva
                        clientes[i].estadoID = 1;
                        clientes[i].estado = context.estados_cliente.Find(1);
                        modificarCliente(clientes[i]);
                        break;
                    }
                    else
                    {
                        clientes[i].estadoID = 2;
                        clientes[i].estado = context.estados_cliente.Find(2);
                        modificarCliente(clientes[i]);
                        break;
                    }

                }
            }

            DesasignarHabitacionesHuespedesReserva(reserva);
        }


        public int reservasPosteriores(int cliente_id)
        {

           Cliente cliente = retornarCliente(cliente_id);
           int numero_reservas_posteriores = 0;
           for (int i = 0; i < cliente.reservas.Count(); i++)
           {
               if (cliente.reservas.ElementAt(i).estadoID == 1)
               {
                   numero_reservas_posteriores += 1;
               }

           }

           return numero_reservas_posteriores;
        }


        //bicho prueba
        public void cambiarEstadoCheckOutCliente(int id_cliente, Reserva reserva)
        {
            Cliente cliente = retornarCliente(id_cliente);

            int numero_reservas_posteriores;
         
                if ((reserva.estado.ID == 3) || (reserva.estado.ID == 4))
                {

                    numero_reservas_posteriores = reservasPosteriores(id_cliente);
                    if (numero_reservas_posteriores == 0)
                    {
                        // falta condicion para que se pueda determinar si se debe cambiar a sin reserva o con reserva
                        cliente.estadoID = 1;
                        cliente.estado = context.estados_cliente.Find(1);
                        cliente.habitacion_asignada = "-";
                        modificarCliente(cliente);
                    }
                    else
                    {
                        cliente.estadoID = 2;
                        cliente.estado = context.estados_cliente.Find(2);
                        cliente.habitacion_asignada = "-";
                        modificarCliente(cliente);
                      
                    }
                   
                }
            
        }


        public void cambiarEstadoEliminarReserva(int id_cliente_reserva)
        {
            Cliente clientes = context.clientes.Find(id_cliente_reserva);
            int numero_reservas_posterior = reservasPosteriores(id_cliente_reserva);
                {

                    if (numero_reservas_posterior == 0)
                    {
                        // falta condicion para que se pueda determinar si se debe cambiar a sin reserva o con reserva
                        clientes.estadoID = 1;
                        clientes.estado = context.estados_cliente.Find(1);
                        modificarCliente(clientes);
                        
                    }
                    else
                    {
                        clientes.estadoID = 2;
                        clientes.estado = context.estados_cliente.Find(2);
                        modificarCliente(clientes);
                    }

                }
         
        }

        public void cambiarEstadoAnularReserva(int id_cliente_reserva)
        {
            cambiarEstadoEliminarReserva(id_cliente_reserva);
        }


        public void incrementaNumeroReservas(Cliente cliente)
        {
            cliente.numero_reservas++;
            modificarCliente(cliente);
        }

        public void DecrementaNumeroReservas(Cliente cliente)
        {
            cliente.numero_reservas--;
            modificarCliente(cliente);
        }


        public int toCliente(string cliente_raw)
        {
            try
            {
                string tipo = cliente_raw.Substring(cliente_raw.LastIndexOf(',') + 2);
                string documento = cliente_raw.Substring(cliente_raw.LastIndexOf(' ') + 1);
                int tipo_persona, tipo_documentoID;
                if (tipo[0] == 'D') tipo_persona = tipo_documentoID = 1;
                else if (tipo[0] == 'P')
                {
                    tipo_persona = 1;
                    tipo_documentoID = 2;
                }
                else
                {
                    tipo_persona = 2;
                    tipo_documentoID = 3;
                }
                var documento_identidad = documento;
                int clienteID = 0;
                if (tipo_persona == 1)
                    clienteID = context.clientes.First(c => c.tipoID == tipo_persona && c.documento_identidad == documento && c.tipo_documentoID == tipo_documentoID).ID;
                if (tipo_persona == 2)
                    clienteID = context.clientes.First(c => c.tipoID == tipo_persona && c.ruc == documento).ID;
                return clienteID;
            }
            catch (Exception e) { return 0; }
        }


        public List<Ciudad> retornarCiudades(int pais_id)
        {
            List<Ciudad> res = (new EraSphereContext()).paises.Find(pais_id).ciudades.ToList();
            return res;
        }

    }
}