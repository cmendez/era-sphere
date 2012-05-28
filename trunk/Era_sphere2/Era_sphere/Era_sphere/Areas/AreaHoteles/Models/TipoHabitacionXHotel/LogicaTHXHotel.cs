using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.TipoHabitacionXHotel
{
    public class LogicaTHXHotel
    {
        public EraSphereContext context = new EraSphereContext();
        DBGenericQueriesUtil<Piso> database_table;
        DBGenericQueriesUtil<Hotel> database_table_hotel;

        public LogicaTHXHotel()
        {
            database_table = new DBGenericQueriesUtil<Piso>(context, context.pisos);
            database_table_hotel = new DBGenericQueriesUtil<Hotel>(context, context.hoteles);
        }

        public List<PisoView> retornarPisos()
        {
            List<Piso> pisos = database_table.retornarTodos();
            List<PisoView> pisos_view = new List<PisoView>();

            foreach (Piso piso in pisos) pisos_view.Add(new PisoView(piso));
            return pisos_view;
        }

        public PisoView retornarPiso(int pisoID)
        {
            Piso piso_aux=database_table.retornarUnSoloElemento(pisoID);
            PisoView piso = new PisoView(piso_aux);
            return piso;
        }

        public void modificarPiso(PisoView piso_view)
        {
            Piso piso = piso_view.deserializa(this);
            Piso orig = database_table.retornarUnSoloElemento(piso_view.ID);
            orig.codigo_piso = piso.codigo_piso ?? orig.codigo_piso;
            orig.descripcion = piso.descripcion ?? orig.descripcion;
            database_table.modificarElemento(orig, piso.ID);
        }

        public void agregarPiso(PisoView piso)
        {
            database_table.agregarElemento(piso.deserializa(this));
        }

        public void eliminarPiso(int pisoID)
        {
            database_table.eliminarElemento(pisoID);
        }

        public List<Piso> buscarPiso(Piso piso_campos)
        {
            return database_table.buscarElementos(piso_campos);
        }

        //retorna un hotel
        public string retornaNombreHotel(int hotel_id)
        {
            Hotel hotel_perteneciente = database_table_hotel.retornarUnSoloElemento(hotel_id);
            return hotel_perteneciente.razon_social;
            //  return hotel_perteneciente.descripcion;
        }

        public List<PisoView> retornarPisosDeHotel(int hotel_id)
        {
            List<Piso> pisos_aux = database_table.retornarTodos().Where(p => p.hotelID == hotel_id).ToList();
            List<PisoView> pisos_view = new List<PisoView>();

            foreach (Piso piso in pisos_aux) pisos_view.Add(new PisoView(piso));
            return pisos_view;
           
        }

    }
}