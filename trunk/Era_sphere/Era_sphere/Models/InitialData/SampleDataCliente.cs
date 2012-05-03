using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.AreaCliente.Models;

namespace Era_sphere.Models
{
    public class SampleDataCliente : DropCreateDatabaseIfModelChanges<ClienteContext>
    {
        protected override void Seed(ClienteContext context)
        {
            var clientes = new List<Cliente>
            {

            };
        }
    }
}