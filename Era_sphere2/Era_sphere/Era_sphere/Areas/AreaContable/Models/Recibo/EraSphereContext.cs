using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Recibo> recibos { get; set; }
        public DbSet<ReciboLinea> recibos_lineas { get; set; }
        public DbSet<ReciboLineaXReserva> recibos_linea_x_reserva { get; set; }
        public DbSet<ReciboLineaXEvento> recibos_linea_x_evento { get; set; }
    }
}
