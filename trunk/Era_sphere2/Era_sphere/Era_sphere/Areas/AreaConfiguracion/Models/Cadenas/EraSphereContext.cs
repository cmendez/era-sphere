using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Cadenas;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Cadena> cadenas { get; set; }

        void seedCadena() {
            cadenas.Add(
                new Cadena
                {

                    nombreCadena = "Default",
                    rsocial = "Default",
                    ruc = "11111111111",
                    url = "http://pagina.com",
                    adel_minimo = 0,
                    d_ant_ret = 0,
                    porc_ret = 0,
                    ptos_x_dolar = 0,
                    hostname = "",
                    port = "",
                    username = "",
                    password = ""

                }
                );
        }
    }
}
