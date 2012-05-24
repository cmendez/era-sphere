﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class UbigeoInitializer : DropCreateDatabaseIfModelChanges<EraSphereContext>
    {
        public void Seed(EraSphereContext context)
        {
            var _paises = new List<Pais>
            {
                new Pais{nombre = "Peru", ID = 1},
                new Pais{nombre = "Uruguay", ID = 2},
                new Pais{nombre = "Chile", ID = 3},
                new Pais{nombre = "Argentina", ID = 4},
                new Pais{nombre = "Brasil", ID = 5},
                new Pais{nombre = "Colombia", ID = 6},
                new Pais{nombre = "Venezuela", ID = 7},
                new Pais{nombre = "Ecuador", ID = 8}
            };
            foreach (var p in _paises)
                context.paises.Add(p);
            context.SaveChanges();
            /*
            var _ciudades = new List<Ciudad>
            {
                new Ciudad{nombre = "Lima", ID = 1, pais = _paises.Single(p => p.nombre == "Peru")},
                new Ciudad{nombre = "Montevideo", ID = 2, pais = _paises.Single(p => p.nombre == "Uruguay")},
                new Ciudad{nombre = "Santiago de Chile", ID = 3, pais = _paises.Single(p => p.nombre == "Chile")},
                new Ciudad{nombre = "Buenos Aires", ID = 4, pais = _paises.Single(p => p.nombre == "Argentina")},
                new Ciudad{nombre = "Brasilia", ID = 5, pais = _paises.Single(p => p.nombre == "Brasil")},
                new Ciudad{nombre = "Bogota", ID = 6, pais = _paises.Single(p => p.nombre == "Colombia")},
                new Ciudad{nombre = "Caracas", ID = 7, pais = _paises.Single(p => p.nombre == "Venezuela")},
                new Ciudad{nombre = "Quito", ID = 8, pais = _paises.Single(p => p.nombre == "Ecuador")}
            };
            foreach (var c in _ciudades)
                context.ciudades.Add(c);
            context.SaveChanges();
            _paises = context.paises.ToList();
            for (int i = 0; i < _paises.Count; i++)
            {
                var pais = _paises[i];
                pais.ciudades = new List<Ciudad>() { context.ciudades.ToList().Find(c => c.pais.nombre == pais.nombre) };
                pais.ciudades.First().pais = pais;
            }
            context.SaveChanges();*/
        }
    }
    
}