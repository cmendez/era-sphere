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

        void agregarAreaEmpleados()
        {
            List<SubLink> AreaEmpleados = new List<SubLink>();
            AreaEmpleados.Add(
                    new SubLink
                    {
                        Nombre = "Administrar Empleados",
                        Url = "/AreaEmpleados/Empleado"
                    }
            );
            AreaEmpleados.Add(
                    new SubLink
                    {
                        Nombre = "Asistencia Empleados",
                        Url = "/AreaEmpleados/AsistenciaEmpleado"
                    }
            );
            menu.Add(
              new Link()
              {
                  Nombre = "Empleados",
                  Url = "#",
                  Icono = "icon_pen",
                  Sublinks = AreaEmpleados
              }
              );
        }

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
                        Nombre = "Tipos de habitaciones",
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

            AreaConfiguracion.Add(new SubLink
            {
                Nombre = "Promociones",
                Url = "/AreaPromociones/Promocion"
            });


            AreaConfiguracion.Add(new SubLink { 
                Nombre = "Perfiles",
                Url    = "/AreaConfiguracion/Perfiles"
            });

            AreaConfiguracion.Add(new SubLink { 
                Nombre = "Monedas",
                Url= "/AreaConfiguracion/Moneda"
            });

            AreaConfiguracion.Add(new SubLink { 
                Nombre = "Fiscal",
                Url = "/AreaConfiguracion/Fiscal"
            });

            AreaConfiguracion.Add(new SubLink
            {
                Nombre = "Tipos de Servicios",
                Url = "/AreaConfiguracion/TipoServicio"
            });

            AreaConfiguracion.Add(new SubLink
            {
                Nombre = "Tipos de Pago",
                Url = "/AreaConfiguracion/TipoDePago"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Cadena",
                Url = "/AreaConfiguracion/Cadena"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Comodidades",
                Url = "/AreaHoteles/Comodidades"
            });
            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Temporadas",
                Url = "/AreaConfiguracion/Temporada"
            });

            AreaConfiguracion.Add(new SubLink()
            {
                Nombre = "Tipo  de temporadas",
                Url = "/AreaConfiguracion/TipoTemporada"
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

        void agregarAreaClientes()
        {
            this.menu.Add(new Link()
            {
                Nombre = "Clientes",
                Url = "/../AreaClientes/Cliente",
                Icono = "icon_pen",
                Sublinks = new List<SubLink>()
            });
        }

        public NavegacionModel()
        {

            this.menu = new List<Link>();


            agregarAreaClientes();
            agregarAreaEmpleados();
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
            
            if ( token == "all" ){
                return this.menu;
            }

            for (int i = 0; i < token.Length; i++)
                if (token[i] == '1') retorno.Add(this.menu[i]);
            return retorno;
        }
    }
}