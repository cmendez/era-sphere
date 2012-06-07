using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
namespace Era_sphere.Areas.AreaClientes.Models
{
    public class TipoDocumentoCliente:DBable
    {
        public string descripcion { get; set; }
        public virtual ICollection<Cliente> lista_clientes { get; set; }
    }
}