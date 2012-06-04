using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class LogicaComodidades : InterfazLogicaComodidades
    {
        EraSphereContext comodidad_context = new EraSphereContext();
        
        DBGenericQueriesUtil<Comodidad> database_table;
        


        public LogicaComodidades()
        {
            database_table = new DBGenericQueriesUtil<Comodidad>(comodidad_context, comodidad_context.comodidades);
            
        }
        public List<Comodidad> retonarLista()
        {
            List<Comodidad> comodidades = database_table.retornarTodos();
            return comodidades;
        }


        public List<ComodidadView> retornarComodidades()
        {
            List<Comodidad> comodidades= database_table.retornarTodos();
            List<ComodidadView> comodidad_view = new List<ComodidadView>();

            foreach (Comodidad comodidad in comodidades) comodidad_view.Add(new ComodidadView(comodidad));
            return comodidad_view;
            
        }

        public List<ComodidadView> retornarComodidades(int tipoHabitacionID)
        {
            List<Comodidad> comodidades = database_table.retornarTodos();
            List<ComodidadView> comodidad_view = new List<ComodidadView>();
            LogicaTipoHabitacion lth = new LogicaTipoHabitacion();
            TipoHabitacion tipoHabitacion = (new EraSphereContext()).tipos_habitacion.Find(tipoHabitacionID);

            foreach (Comodidad comodidad in comodidades) 
                if(comodidad.tiposHabitacion.Contains(tipoHabitacion))
                    comodidad_view.Add(new ComodidadView(comodidad));
            return comodidad_view;
        }


        public void agregarComodidad(ComodidadView comodidad)
        {
            //int id = comodidad.estadoID;
            database_table.agregarElemento(comodidad.deserializa());
        }

        public void eliminarComodidad(int comodidad_id)
        {
            database_table.eliminarElemento(comodidad_id);
        }

        public void modificarComodidad(ComodidadView comodidad_view)
        {
            Comodidad comodidad = comodidad_view.deserializa();
            database_table.modificarElemento(comodidad, comodidad.ID);
            return;
        }
        public ComodidadView retornarComodidad(int comodidad_id)
        {
            Comodidad comodidad = database_table.retornarUnSoloElemento(comodidad_id);
            ComodidadView comodidad_view = new ComodidadView(comodidad);
            return comodidad_view;
        }
    }
}