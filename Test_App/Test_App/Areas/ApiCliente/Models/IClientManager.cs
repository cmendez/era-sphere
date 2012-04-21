using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_App.Areas.ApiCliente.Models
{
    interface IClientManager
    {
        string agregar_cliente(Cliente cliente);
        List<Cliente> retornar_clientes();
        string modificar_cliente(Cliente cliente);
        string eliminar_cliente(Cliente cliente);
    }
}