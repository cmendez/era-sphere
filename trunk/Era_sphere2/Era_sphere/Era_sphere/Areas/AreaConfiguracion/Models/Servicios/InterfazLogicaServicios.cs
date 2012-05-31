using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    interface InterfazLogicaServicios
    {
        void modificarServicio(ServicioView servicio);
        void agregarServicio(ServicioView servicio);
        void eliminarServicio(int servicio_id);
        List<ServicioView> retornarServicios();
        ServicioView retornarServicio(int servicio_id);
        List<Servicio> buscarServicio(Servicio servicio);
    }
}
