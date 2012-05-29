using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaPaquetes.Models
{
    public class LogicaPaquete : InterfazLogicaPaquete
    {
    /*    EraSphereContext paquete_context = new EraSphereContext();
        DBGenericQueriesUtil<Paquete> database_table;
        
        public LogicaPaquete()
        {   
            database_table = new DBGenericQueriesUtil< Paquete >(paquete_context, paquete_context.paquetes);
        }

        public List<PaqueteView> retornarPaquetes( int hotel_id )
        {
            IEnumerable<Paquete> paquetes = database_table.retornarTodos();//.Where( p => p.piso.hotel.ID == id_hotel );
            List<PaqueteView> paquete_view = new List<PaqueteView>();

            foreach (Paquete paquete in paquetes) paquete_view.Add(new PaqueteView(paquete));
            return paquete_view;
        }

        public PaqueteView retornarPaquete(int paquete_id)
        {
            Paquete paquete = database_table.retornarUnSoloElemento(paquete_id);
            PaqueteView paquete_view = new PaqueteView(paquete);
            return paquete_view;
        }

        public void modificarPaquete(PaqueteView paquete_view)
        {
            Paquete modif = paquete_view.deserializa(this);  
            database_table.modificarElemento(modif, modif.ID);
            return;
        }

        public void agregarPaquete(PaqueteView paquete)
        {
            Paquete paquete_per = paquete.deserializa(this);
            //paquete_per.tipoHabitacion = habitacion_context.tipos_habitacion.Find(habitacion_per.tipoHabitacionID);
            //paquete_per.estado = habitacion_context.estado_espacio_rentable.Find(habitacion.estado_habitacionID);
            //paquete_per.piso = habitacion_context.pisos.Find(habitacion.pisoID);
            database_table.agregarElemento(paquete_per);
        }

        public void eliminarPaquete(int paquete_id)
        {
            database_table.eliminarElemento(paquete_id);
        }
        */
    }
}