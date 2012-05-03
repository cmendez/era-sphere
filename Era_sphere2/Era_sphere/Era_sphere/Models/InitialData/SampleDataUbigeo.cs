using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Areas.Configuracion.Models;

namespace Era_sphere.Models
{
    public class SampleDataUbigeo : DropCreateDatabaseIfModelChanges<UbigeoContext>
    {
        protected override void Seed(UbigeoContext context)
        {
            var paises = new List<Pais>
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

            var ciudades = new List<Ciudad>
            {
                new Ciudad{nombre = "Lima", ID = 1, pais = paises.Single(p => p.nombre == "Peru")},
                new Ciudad{nombre = "Montevideo", ID = 2, pais = paises.Single(p => p.nombre == "Uruguay")},
                new Ciudad{nombre = "Santiago de Chile", ID = 3, pais = paises.Single(p => p.nombre == "Chile")},
                new Ciudad{nombre = "Buenos Aires", ID = 4, pais = paises.Single(p => p.nombre == "Argentina")},
                new Ciudad{nombre = "Brasilia", ID = 5, pais = paises.Single(p => p.nombre == "Brasil")},
                new Ciudad{nombre = "Bogota", ID = 6, pais = paises.Single(p => p.nombre == "Colombia")},
                new Ciudad{nombre = "Caracas", ID = 7, pais = paises.Single(p => p.nombre == "Venezuela")},
                new Ciudad{nombre = "Quito", ID = 8, pais = paises.Single(p => p.nombre == "Ecuador")}
            };
            foreach (var pais in paises)
            {
                foreach (var ciudad in ciudades.Where(p => p.pais == pais))
                    pais.ciudades.Add(ciudad);
            }
            ciudades.ForEach(p => context.ciudades.Add(p));
        }
    }
}