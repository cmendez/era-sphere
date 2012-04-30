using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Models
{
    public class LogicaCliente: InterfazLogicaCliente
    {
        ClienteEntities cliente_context=new ClienteEntities();
 
        public List<Cliente> retornarClientes()
        {
            var clientes = cliente_context.clientes;

            return clientes.ToList();
        }

        public Cliente retornarCliente(int cliente_id)
        {
            var clientes = cliente_context.clientes;
            return clientes.Find(cliente_id);
        }

        public void modificarCliente(Cliente cliente)
        {
            //@toDo
        }
        public void agregarClientes(Cliente cliente)
        {
            var clientes = cliente_context.clientes;
            clientes.Add(cliente);
            cliente_context.SaveChanges();
        }
        public void eliminarCliente(int cliente_id)
        {
            var clientes = cliente_context.clientes;
            var cliente_delete = clientes.Find(cliente_id);
            clientes.Remove(cliente_delete);
            cliente_context.SaveChanges();
        
        }
        //revisar: "cliente o no cliente"
        public List<Cliente> buscarCliente(Cliente cliente)
        {
            var clientes = cliente_context.clientes;
            //@ToDo
            return null;
        }
    }
}