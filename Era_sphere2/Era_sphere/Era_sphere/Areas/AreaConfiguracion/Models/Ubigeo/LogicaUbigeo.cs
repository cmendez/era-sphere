using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class LogicaUbigeo : InterfazLogicaUbigeo
    {
        EraSphereContext pais_context = new EraSphereContext();
        //public EraSphereContext context_publico { get { return pais_context; } }
        DBGenericQueriesUtil<Pais> database_table;

        public LogicaUbigeo()
        {
            database_table = new DBGenericQueriesUtil<Pais>(pais_context, pais_context.paises);
        }

        public void modificarPais(PaisView pais_view)
        {
            Pais pais = pais_view.deserializa();
            database_table.modificarElemento(pais, pais.ID);
        }

        
       
        public List<PaisView> retornarPaisesFiltro(String nombre )
        {
            List<Pais> paises = database_table.retornarTodos();
            List<PaisView> paises_view = new List<PaisView>();
            foreach (Pais pais in paises) 
                if (pais.nombre.ToUpper().Contains(nombre.ToUpper())) paises_view.Add(new PaisView(pais));
            return paises_view;
        }


        public List<PaisView> retornarPaises()
        {
            List<Pais> paises = database_table.retornarTodos();
            List<PaisView> paises_view = new List<PaisView>();

            foreach (Pais pais in paises) paises_view.Add(new PaisView(pais));

            return paises_view;
        }

        public List<Ciudad> retornarCiudades()
        {
            return pais_context.ciudades.ToList();
        }

        public List<Provincia> retornarProvincias()
        {
            return pais_context.provincias.ToList();
        }
    }
}