using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Models
{
    public class InterfazLogicaCliente
    {
        public interface InterfazLogicaCliente
        {
            public List<Cliente> retornarClientes();
            public Cliente retornarCliente(int cliente_id);
            public void modificarClientes(Cliente cliente);
            public void agregarClientes(Cliente cliente);
            public void eliminarCliente(int cliente_id);
            //revisar: "cliente o no cliente"
            public List<Cliente> buscarCliente(Cliente cliente);

        }
    }
}