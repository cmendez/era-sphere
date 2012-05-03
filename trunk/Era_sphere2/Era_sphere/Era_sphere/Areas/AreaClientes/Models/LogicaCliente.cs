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
    public class LogicaCliente: InterfazLogicaCliente
    {
        ClienteContext cliente_context=new ClienteContext();
        DBGenericQueriesUtil<Cliente> database_table;

        public LogicaCliente()
        {
            database_table = new DBGenericQueriesUtil<Cliente>(cliente_context, cliente_context.clientes);
        }

        public List<Cliente> retornarClientes()
        {
            return database_table.retornarTodos();
        }

        public Cliente retornarCliente(int clienteID)
        {
            return database_table.retornarUnSoloElemento(clienteID);
        }

        public void modificarCliente(Cliente cliente)
        {
            database_table.modificarElemento(cliente, cliente.ID);
        }

        public void agregarCliente(Cliente cliente)
        {
            database_table.agregarElemento(cliente);
        }

        public void eliminarCliente(int clienteID)
        {
            database_table.eliminarElemento(clienteID);
        }

        public List<Cliente> buscarCliente(Cliente cliente_campos)
        {
            return database_table.buscarElementos(cliente_campos);
        }
    }
}