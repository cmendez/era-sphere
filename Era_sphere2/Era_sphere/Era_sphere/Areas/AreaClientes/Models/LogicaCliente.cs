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
        public EraSphereContext cliente_context=new EraSphereContext();
        DBGenericQueriesUtil<Cliente> database_table;

        public LogicaCliente()
        {
            database_table = new DBGenericQueriesUtil<Cliente>(cliente_context, cliente_context.clientes);
        }

        public List<ClienteView> retornarClientes()
        {
            
            List<Cliente> clientes = database_table.retornarTodos();
            List<ClienteView> clientes_view = new List<ClienteView>();

            foreach (Cliente cliente in clientes) clientes_view.Add(new ClienteView(cliente));
            return clientes_view;
        }

        public ClienteView retornarCliente(int id_cliente)
        {
            Cliente cliente = database_table.retornarUnSoloElemento(id_cliente);
            ClienteView cliente_view = new ClienteView(cliente);
            return cliente_view;
        }

        public void modificarCliente(ClienteView cliente_view)
        {
            Cliente cliente = cliente_view.deserializa(this);
            database_table.modificarElemento(cliente, cliente.ID);

        }

        public void agregarCliente(ClienteView cliente_view)
        {
            database_table.agregarElemento(cliente_view.deserializa(this));
        }

        public void eliminarCliente(int cliente_id)
        {
            database_table.eliminarElemento(cliente_id);
        }

        public List<Cliente> buscarCliente(Cliente cliente_campos)
        {
            return database_table.buscarElementos(cliente_campos);
        }
    }
}