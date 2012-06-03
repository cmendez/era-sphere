using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class LogicaServicios
    {
        EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Servicio> tabla_servicios, tabla_tipo_servicios;

        public LogicaServicios()
        {
            tabla_servicios = new DBGenericQueriesUtil<Servicio>(context, context.servicios);
        }

        public List<ServicioView> retornarServicios()
        {
            List<Servicio> servicios = tabla_servicios.retornarTodos();
            List<ServicioView> servicios_view = new List<ServicioView>();

            foreach (Servicio servicio in servicios) servicios_view.Add(new ServicioView(servicio));
            return servicios_view;
        }

        public ServicioView retornarServicio(int servicioID)
        {
            Servicio servicio_aux = tabla_servicios.retornarUnSoloElemento(servicioID);
            ServicioView servicio = new ServicioView(servicio_aux);
            return servicio;
        }

        public void modificarServicio(ServicioView servicio_view)
        {
            Servicio servicio = servicio_view.deserializa();
            tabla_servicios.modificarElemento(servicio, servicio.ID);
        }

        public void agregarServicio(ServicioView servicio)
        {
            tabla_servicios.agregarElemento(servicio.deserializa());
        }

        public void eliminarServicio(int servicioID)
        {
            tabla_servicios.eliminarElemento(servicioID);
        }

        public List<Servicio> buscarServicio(Servicio servicio_campos)
        {
            return tabla_servicios.buscarElementos(servicio_campos);
        }




        internal object retornarTipoServicios()
        {
            throw new NotImplementedException();
        }
    }
}