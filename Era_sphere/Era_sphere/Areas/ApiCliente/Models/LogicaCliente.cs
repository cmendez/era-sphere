using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Models.ClienteEntities;

namespace Era_sphere.Models
{
    public class LogicaCliente: InterfazLogicaCliente
    {
        ClienteEntities cliente_context;
 
        public List<Cliente> retornarClientes()
        {
            return 
        }

        public Cliente retornarCliente(int cliente_id);
        public void modificarClientes(Cliente cliente);
        public void agregarClientes(Cliente cliente);
        public void eliminarCliente(int cliente_id);
        //revisar: "cliente o no cliente"
        public List<Cliente> buscarCliente(Cliente cliente);
    }
}