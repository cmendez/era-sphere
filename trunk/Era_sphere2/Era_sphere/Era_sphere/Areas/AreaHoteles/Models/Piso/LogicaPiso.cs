using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class LogicaPiso : InterfazLogicaPiso
    {
        PisoContext piso_context=new PisoContext();
        DBGenericQueriesUtil<Piso> database_table;

        public LogicaPiso()
        {
            database_table = new DBGenericQueriesUtil<Piso>(piso_context, piso_context.pisos);
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
            return;
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
    }
}