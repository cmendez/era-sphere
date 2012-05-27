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

        void agregarAreaHotel() { 
        
            List<SubLink> AreaHoteles = new List<SubLink>();
            AreaHoteles.Add(
                    new SubLink
                    {
                        Nombre = "Agregar Hotel",
                        Url = "/AreaHoteles/Hotel"
                    }
            );


            AreaHoteles.Add(
                    new SubLink
                    {
                        Nombre = "Administrar Hoteles",
                        Url = "/AreaHoteles/AdministrarHotel"
                    }
            );
            AreaHoteles.Add(
                    new SubLink
                    {
                        Nombre = "Agregar Tipo Habitacion",
                        Url = "/AreaHoteles/TipoHabitacion"
                    }
                );


             menu.Add(
                    new Link() { 
                        Nombre = "Hoteles",
                        Url ="#",
                        Icono = "icon_pen",
                        Sublinks = AreaHoteles
                    }
                );
        }


        void agregarConfiguracion() {
            List<SubLink> AreaConfiguracion = new List<SubLink>();
            AreaConfiguracion.Add(new SubLink { 
                Nombre = "Administrar Perfiles",
                Url    = "/AreaConfiguracion/Perfiles"
            });

            AreaConfiguracion.Add(new SubLink { 
                Nombre = "Agregar Monedas",
                Url= "/AreaConfiguracion/Moneda"
            });
            AreaConfiguracion.Add(new SubLink
            {
                Nombre = "Agregar Tipo Pago",
                Url = "/AreaConfiguracion/TipoDePago"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Cadena",
                Url = "../AreaConfiguracion/Cadena"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Comodidades",
                Url = "../AreaHoteles/Comodidades"
            });
            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Temporada",
                Url = "../AreaConfiguracion/Temporada"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Tipo Temporada",
                Url = "../AreaConfiguracion/TipoTemporada"
            });

            
            menu.Add(
                new Link()
                {
                    Nombre="Configuracion",
                    Url="#",
                    Icono="icon_pen",
                    Sublinks = AreaConfiguracion

                }
                );
        }
        public NavegacionModel()
        {

            this.menu = new List<Link>();

            agregarAreaHotel();
            agregarConfiguracion();
          
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