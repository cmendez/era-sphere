using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaPiso:InterfazLogicaPiso
    {
        PisoContext piso_context = new PisoContext();
        DBGenericQueriesUtil<Piso> database_table;

        public LogicaPiso() {
            database_table = new DBGenericQueriesUtil<Piso>(piso_context, piso_context.pisos);
        }


        void agregarPiso(PisoView piso)
        {   
            database_table.agregarElemento(piso.deserializa(this));
        }

        void modificarPiso(PisoView piso_view)
        {
            Piso piso = piso_view.deserializa(this);
            return;
        }

        void eliminarHotel(int piso_id)
        {
            database_table.eliminarElemento(piso_id);
            return;
        }
        List<PisoView> retornarPisos(int hotel_id)
        {
            List<Piso> pisos = database_table.retornarTodos();
            List<PisoView> pisos_view = new List<PisoView>();

            foreach (Piso piso in pisos) pisos_view.Add(new PisoView(piso));
            return pisos_view;
        }
        PisoView retornarPiso(int piso_id)
        {
            Piso piso = database_table.retornarUnSoloElemento(piso_id);
            PisoView piso_view = new PisoView(piso);
            return piso_view;
        }
        //HotelView retornarPiso(int ciudad_id);
        //List<EspacioCargable> retornarEspaciosCargables(int piso_id);
    }
}