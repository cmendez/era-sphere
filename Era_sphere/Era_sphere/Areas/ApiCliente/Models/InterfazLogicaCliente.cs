using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Models
{
  
        public interface InterfazLogicaCliente
        {
            List<Cliente> retornarClientes();
            Cliente retornarCliente(int cliente_id);
            void modificarCliente(Cliente cliente);
            void agregarClientes(Cliente cliente);
            void eliminarCliente(int cliente_id);
            //revisar: "cliente o no cliente"
            List<Cliente> buscarCliente(Cliente cliente);

        }
}