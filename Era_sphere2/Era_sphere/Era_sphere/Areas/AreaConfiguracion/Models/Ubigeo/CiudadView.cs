using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class CiudadView
    {
        public string Nombre;
        public int ID;

        public CiudadView(Ciudad ciudad)
        {
            this.ID = ciudad.ID;
            this.Nombre = ciudad.nombre;
        }
    }
}