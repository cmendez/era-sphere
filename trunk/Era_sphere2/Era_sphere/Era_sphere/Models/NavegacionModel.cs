using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Models
{
    public class SubLink
    {
        public string Nombre { get; set; }
        public string Url { get; set; }
    }

    public class Link
    {
        //esta clase es para el link
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Icono { get; set; }
        public List<SubLink> Sublinks;
    }

    public class NavegacionModel
    {
        public List<Link> menu;
        public NavegacionModel()
        {
            List<SubLink> sl = new List<SubLink>();
            sl.Add(new SubLink()
            {
                Nombre = "Cadena",
                Url = "../AreaConfiguracion/Cadena"
            });

            

            this.menu = new List<Link>();
            this.menu.Add(new Link()
            {
                Nombre = "Configuracion",
                Url = "#",
                Icono = "icon_email",
                Sublinks = sl
            });

            this.menu.Add(new Link()
            {
                Nombre = "menu 2",
                Url = "#",
                Icono = "icon_email",
                Sublinks = new List<SubLink>()
            });

            this.menu.Add(new Link()
            {
                Nombre = "Salir",
                Url = "/../..",
                Icono = "icon_logout",
                Sublinks = new List<SubLink>()
            });

        }

        public IEnumerable<Link> getMenu(string token)
        {
            List<Link> retorno = new List<Link>();
            for (int i = 0; i < token.Length; i++)
                if (token[i] == '1') retorno.Add(this.menu[i]);
            return retorno;
        }
    }
}