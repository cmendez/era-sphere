using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using System.Web.Mvc;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaTipoHabitacion
    {
        EraSphereContext tipohabitacion_context = new EraSphereContext();
        DBGenericQueriesUtil<TipoHabitacion> database_table;
        
        public LogicaTipoHabitacion()
        {   
            database_table = new DBGenericQueriesUtil< TipoHabitacion >(tipohabitacion_context, tipohabitacion_context.tipos_habitacion);
        }

        public List<TipoHabitacionView> retornarTiposHabitacion()
        {
            List<TipoHabitacion> tipoHabitaciones = database_table.retornarTodos();
            List<TipoHabitacionView> tipoHabitacion_view = new List<TipoHabitacionView>();

            foreach (TipoHabitacion tipoHabitacion in tipoHabitaciones) tipoHabitacion_view.Add(new TipoHabitacionView(tipoHabitacion));
            return tipoHabitacion_view;
        }
        
        public void agregarComodidad(int comodidad_id,int tipohabitacion_id){
            TipoHabitacion th = retornarObjTipoHabitacion(tipohabitacion_id);
            Comodidad comodidad = tipohabitacion_context.comodidades.Find(comodidad_id);
            th.comodidades.Add(comodidad);
            database_table.modificarElemento(th, th.ID);
            return;
        }

        public void eliminarComodidad(int comodidad_id, int tipohabitacion_id)
        {
            TipoHabitacion th = retornarObjTipoHabitacion(tipohabitacion_id);
            Comodidad comodidad = tipohabitacion_context.comodidades.Find(comodidad_id);
            th.comodidades.Remove(comodidad);
            database_table.modificarElemento(th, th.ID);
            return;
        }
        public List<Comodidad> retornarComodidades(int tipohabitacion_id)
        {
            return retornarObjTipoHabitacion(tipohabitacion_id).comodidades.ToList();
        }

        public List<ComodidadView> retornarComodidadesView(int tipohabitacion_id)
        {
            List<ComodidadView> comodidades_view= new List<ComodidadView>();
            List<Comodidad> comodidades = retornarObjTipoHabitacion(tipohabitacion_id).comodidades.ToList();
            foreach (Comodidad comodidad in comodidades) comodidades_view.Add(new ComodidadView(comodidad));
            return comodidades_view;
        }

        public TipoHabitacionView retornarTipoHabitacion(int tipohabitacion_id)
        {
            TipoHabitacion tipoHabitacion = database_table.retornarUnSoloElemento(tipohabitacion_id);
            TipoHabitacionView tipoHabitacion_view = new TipoHabitacionView(tipoHabitacion);
            return tipoHabitacion_view;
        }

        public TipoHabitacion retornarObjTipoHabitacion(int tipohabitacion_id)
        {
            return database_table.retornarUnSoloElemento(tipohabitacion_id);
        }

        public void modificarTipoHabitacion(TipoHabitacionView tipoHabitacion_view)
        {
            
            TipoHabitacion tipoHabitacion = tipoHabitacion_view.deserializa(this);
            database_table.modificarElemento(tipoHabitacion, tipoHabitacion.ID);
            return;
        }

        public void agregarTipoHabitacion(TipoHabitacionView tipohabitacion)
        {
            database_table.agregarElemento(tipohabitacion.deserializa(this));
        }

        public void eliminarTipoHabitacion(int tipohabitacionID)
        {
            database_table.eliminarElemento(tipohabitacionID);
        }
        public List<TipoHabitacion> buscarTipoHabitacion(TipoHabitacion tipohabitacion_campos)
        {
            return database_table.buscarElementos(tipohabitacion_campos);
        }
        public void agregarComodidades(int tipohabitacion_id, int[] checkedRecord)
        {
            TipoHabitacion tipo_habitacion = tipohabitacion_context.tipos_habitacion.Find(tipohabitacion_id);

            //tipo_habitacion.comodidades= new List<Comodidad> () ;
            foreach (int check in checkedRecord)
            {
                tipo_habitacion.addComodidad(tipohabitacion_context.comodidades.Find(check));
            }
            //database_table.modificarElemento(tipo_habitacion, tipo_habitacion.ID);
            //recorer checkedrecord y agregar comodidades
            //tipo_habitacion.comodidades;
        }

        public List<TipoHabitacion> retornarTipoHabitaciones2()
        {
            return database_table.retornarTodos();
        }

        public TipoHabitacion retornarTipoHabitacion2(int id)
        {
            return tipohabitacion_context.tipos_habitacion.Find(id);
        }
    }
    
}