using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Era_sphere.Models
{
    public class Persona
    {
        int persona_id {get; set;}
        string nombre {get; set;}
        string apellido_paterno {get; set;}
        string apellido_materno { get; set; }
        string dni { get; set; }
        string pasaporte { get; set; }
        string correo_electronico { get; set; }
        string direccion { get; set; }
        string ruc { get; set; }
        string telefono { get; set; }
        string celular { get; set; }
        string razon_social { get; set; }
        Image foto_cliente { get; set; }
        //supuestamente deben de ir los atributos ciudad, país y provincia. 
        DateTime fecha_nacimiento { get; set; }

    }
}