using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_App.Areas.ApiCliente.Models
{
    public class IEClienteController : IClientManager
        {
            List<Cliente> list_clientes;
            public IEClienteController() {
                list_clientes = new List<Cliente>();
                list_clientes.Add(
                        new Cliente
                        {
                            IdCliente = 0,
                            Nombre = "Jp",
                            Dni = "12312",
                            Estado = "Activo"
                        }
                    );
                list_clientes.Add(
                        new Cliente
                        {
                            IdCliente = 1,
                            Nombre = "Andre",
                            Dni = "123123",
                            Estado = "Activo"
                        }
                    );

                list_clientes.Add(
                        new Cliente
                        {
                            IdCliente = 2,
                            Nombre = "Walter",
                            Dni = "123123",
                            Estado = "Pasivo"
                        }
                    );

                list_clientes.Add(
                        new Cliente
                        {
                            IdCliente = 3,
                            Nombre = "Xurreta",
                            Ruc = "412312",
                            Estado = "Pasivo"
                        }
                    );
            }

            public string agregar_cliente(Cliente cliente)
            {
                cliente.Estado = "cabraso";
                list_clientes.Add(cliente);
                return "OK";
            }
            public List<Cliente> retornar_clientes()
            {
                return list_clientes;
            }
            public string modificar_cliente(Cliente cliente)
            {
                for (int i = 0; i < list_clientes.Capacity; i++)
                    if (list_clientes[i].IdCliente == cliente.IdCliente)
                    {
                        list_clientes[i] = cliente;
                        return "OK";
                    }
                throw new Exception("No existe cliente");
            }
            public string eliminar_cliente(Cliente cliente)
            {
                for (int i = 0; i < list_clientes.Capacity; i++)
                    if (list_clientes[i].IdCliente == cliente.IdCliente)
                    {
                        list_clientes[i].Estado = "activo";
                        return "OK";
                    }
                throw new Exception("No existe el cliente");
            }
        }
    
}