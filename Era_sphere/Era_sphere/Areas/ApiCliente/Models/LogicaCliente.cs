using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.DBUtils;

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
            var cliente_db = clientes.Find(cliente.ID);
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
            DBGenericQueriesUtil<Cliente> dbquery = new DBGenericQueriesUtil<Cliente>(cliente_context, cliente_context.clientes);
            cliente.ID = cliente_context.clientes.Max(p => p.ID) + 1;
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
            string where = string.Empty;
            bool first_line = true;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(cliente))
            {
                if (property.GetValue(cliente) != null)
                {
                    var value = property.GetValue(cliente);
                    if(first_line) 
                        first_line = false;
                    else where += " And ";
                    if (property.GetType() == where.GetType()) //query de un string
                        where += property.Name + ".StartsWith(\"" + (string)value + "\")";
                    else //query de cualquier otro tipo de dato
                        where += property.Name + " = " + value;
                }
            }

            return null;
        }
    }
}