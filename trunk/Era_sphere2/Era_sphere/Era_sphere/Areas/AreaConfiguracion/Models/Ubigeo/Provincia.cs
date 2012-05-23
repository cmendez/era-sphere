using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.Configuracion.Models;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Provincia: DBable
    {
        public Provincia(string Nombre, int CiudadID)
        {
            this.Nombre = Nombre;
            this.CiudadID = CiudadID;
        }

        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Ciudad")]
        public int CiudadID { get; set; }



        public virtual Ciudad Ciudad { get; set; }
    }
}