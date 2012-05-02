using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.ApiCliente.Models
{
    public class LogicaCliente: InterfazLogicaCliente
    {
        ClienteContext cliente_context=new ClienteContext();
        DBGenericQueriesUtil<Cliente> database;

        public LogicaCliente()
        {
            database = new DBGenericQueriesUtil<Cliente>(cliente_context, cliente_context.clientes);
        }
        public List<Cliente> retornarClientes()
        {
            return database.retornarTodos();
        }

        public Cliente retornarCliente(int clienteID)
        {
            return database.retornarUnSoloElemento(clienteID);
        }

        public void modificarCliente(Cliente cliente)
        {
            database.modificarElemento(cliente, cliente.ID);
        }

        public void agregarCliente(Cliente cliente)
        {
            database.agregarElemento(cliente);
        }

        public void eliminarCliente(int clienteID)
        {
            database.eliminarElemento(clienteID);
        }

        public List<Cliente> buscarCliente(Cliente cliente_campos)
        {
            return database.buscarElementos(cliente_campos);
        }
    }
}