using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Perfiles
{
    public class Perfil : DBable
    {
        [DisplayName("Nombre asignado al perfil")]
        public string nombrePerfil { get; set; }

        [DisplayName("Descripción del perfil")]
        public string descripcion { get; set; }


        [DisplayName("Lista de visibilidad asignado al perfil")]
        public string listaVisibilidad { get; set; }
    }
}