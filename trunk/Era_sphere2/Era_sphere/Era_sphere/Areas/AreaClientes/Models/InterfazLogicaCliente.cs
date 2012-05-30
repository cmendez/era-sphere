using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaClientes.Models
{
  
        public interface InterfazLogicaCliente
        {
            List<ClienteView> retornarClientes();
            ClienteView retornarCliente(int cliente_id);
            void modificarCliente(ClienteView cliente);
            void agregarCliente(ClienteView cliente);
            void eliminarCliente(int cliente_id);
            //revisar: "cliente o no cliente"
            List<Cliente> buscarCliente(Cliente cliente);

        }
}