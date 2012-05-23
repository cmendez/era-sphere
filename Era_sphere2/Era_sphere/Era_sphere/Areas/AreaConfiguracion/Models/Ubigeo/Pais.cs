using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Pais: DBable
    {
        public Pais(string p, double? IGV)
        {
            this.Nombre = p;
            this.IGV = IGV;
        }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required]
        [Range(0,100)]
        public double? IGV { get; set; }





        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}