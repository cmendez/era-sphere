using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class LogicaServicios : InterfazLogicaServicios
    {
        EraSphereContext servicios_context = new EraSphereContext();
        DBGenericQueriesUtil<Servicio> database_table;

        public LogicaServicios()
        {
            database_table = new DBGenericQueriesUtil<Servicio>(servicios_context, servicios_context.servicios);
        }

        public List<ServicioView> retornarServicios()
        {
            List<Servicio> servicios = database_table.retornarTodos();
            List<ServicioView> servicios_view = new List<ServicioView>();

            foreach (Servicio servicio in servicios) servicios_view.Add(new ServicioView(servicio));
            return servicios_view;
        }

        public ServicioView retornarServicio(int servicioID)
        {
            Servicio servicio_aux = database_table.retornarUnSoloElemento(servicioID);
            ServicioView servicio = new ServicioView(servicio_aux);
            return servicio;
        }

        public void modificarServicio(ServicioView servicio_view)
        {
            Servicio servicio = servicio_view.deserializa();
            database_table.modificarElemento(servicio, servicio.ID);
        }

        public void agregarServicio(ServicioView servicio)
        {
            database_table.agregarElemento(servicio.deserializa());
        }

        public void eliminarServicio(int servicioID)
        {
            database_table.eliminarElemento(servicioID);
        }

        public List<Servicio> buscarServicio(Servicio servicio_campos)
        {
            return database_table.buscarElementos(servicio_campos);
        }

        public List<Servicio> retornarServicios2()
        {
            return database_table.retornarTodos();
        }

    }
}