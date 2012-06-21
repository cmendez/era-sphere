using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class LogicaServicios
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Servicio> tabla_servicios;
        DBGenericQueriesUtil<TipoServicio> tabla_tipo_servicios;

        public LogicaServicios()
        {
            tabla_servicios = new DBGenericQueriesUtil<Servicio>(context, context.servicios);
            tabla_tipo_servicios = new DBGenericQueriesUtil<TipoServicio>(context, context.tipo_servicios);
        }

        public List<ServicioView> retornarServicios()
        {
            List<Servicio> servicios = tabla_servicios.retornarTodos();
            List<ServicioView> servicios_view = new List<ServicioView>();

            foreach (Servicio servicio in servicios) servicios_view.Add(new ServicioView(servicio));
            return servicios_view;
        }

        public List<ServicioView> retornarServicios(int idEvento)
        {
            List<Servicio> servicios = tabla_servicios.retornarTodos().Where(e=>e.eventoID==idEvento).ToList();
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
            Servicio servicio = servicio_view.deserializa(this);
            tabla_servicios.modificarElemento(servicio, servicio.ID);
        }

       

        public void eliminarServicio(int servicioID)
        {
            tabla_servicios.eliminarElemento(servicioID);
        }

        public List<Servicio> buscarServicio(Servicio servicio_campos)
        {
            return tabla_servicios.buscarElementos(servicio_campos);
        }




        public List<TipoServicioView> retornarTipoServicios()
        {
            return tabla_tipo_servicios.retornarTodos().Select(p => new TipoServicioView(p)).ToList();
        }
        public void agregarTipoServicio(TipoServicioView ts_view)
        {
            TipoServicio tipo = ts_view.deserializa(this);
            this.tabla_tipo_servicios.agregarElemento(tipo);
        }

        internal void eliminarTipoServicio(int servicio_id)
        {
            tabla_tipo_servicios.eliminarElemento(servicio_id);
        }

        internal void modificarTipoServicio(TipoServicio p)
        {
            tabla_tipo_servicios.modificarElemento(p, p.ID);
        }

        public List<Servicio> retornarServicios2()
        {
            return context.servicios.ToList();
        }

        public void agregarServicio(Servicio s)
        {
            tabla_servicios.agregarElemento(s);
            s.generaReciboLineas();
        }

        #region evento
        public List<ServicioView> retornarServicioView(int idEvento)
        {
            List<ServicioView> servicio_view = new List<ServicioView>();
            var servicios = tabla_servicios.retornarTodos().Where(p => p.eventoID == idEvento);
            foreach (Servicio servicio in servicios) servicio_view.Add(new ServicioView(servicio));
            return servicio_view;
        }

        internal void agregarServicio(ServicioView servicio)
        {
            tabla_servicios.agregarElemento(servicio.deserializa(this));
        }

        internal decimal RetonarCostos(int idEvento)
        {
            decimal costo = 0;
            List<ServicioView> servicios = retornarServicios(idEvento);
            
            foreach (ServicioView servicio in servicios){
                costo += servicio.precio_final;
            }
            return costo;
        }
#endregion evento
    }
}