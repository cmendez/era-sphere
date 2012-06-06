using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;

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
            //if (cliente_context.clientes.Where(c => c.documento_identidad == cliente.documento_identidad).Count() > 0)
            //{
            //    //MENSAJE DE ERROR URGENTE :) 
            //}
            //else
                database_table.agregarElemento(cliente);
        }

        public void eliminarCliente(int cliente_id)
        {
            database_table.eliminarElemento(cliente_id);
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
    }
}