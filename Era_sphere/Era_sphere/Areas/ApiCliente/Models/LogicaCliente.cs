using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;

namespace Era_sphere.Areas.ApiCliente.Models
{
    public class LogicaCliente: InterfazLogicaCliente
    {
        ClienteContext cliente_context=new ClienteContext();
 
        public List<Cliente> retornarClientes()
        {
            var clientes = cliente_context.clientes;
            return clientes.ToList();
        }

        public Cliente retornarCliente(int clienteID)
        {
            var clientes = cliente_context.clientes;
            return clientes.Find(clienteID);
        }

        public void modificarCliente(Cliente cliente)
        {
            var clientes = cliente_context.clientes;
            var cliente_db = clientes.Find(cliente.clienteID);
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(cliente))
            {
                if (property.GetValue(cliente) != null)
                {
                    property.SetValue(cliente_db, property.GetValue(cliente));
                }
            }
            cliente_context.Entry(cliente_db).State = EntityState.Modified;
            cliente_context.SaveChanges();
        }
        public void agregarClientes(Cliente cliente)
        {
            cliente.clienteID = cliente_context.clientes.Max(p => p.clienteID) + 1;
            var clientes = cliente_context.clientes;
            clientes.Add(cliente);
            cliente_context.SaveChanges();
        }
        public void eliminarCliente(int clienteID)
        {
            var clientes = cliente_context.clientes;
            var cliente_delete = clientes.Find(clienteID);
            clientes.Remove(cliente_delete);
            cliente_context.SaveChanges();
        
        }
        //revisar: "cliente o no cliente"
        public List<Cliente> buscarCliente(Cliente cliente)
        {
            var clientes = cliente_context.clientes;
            //TODO: falta
            return null;
        }
    }
}