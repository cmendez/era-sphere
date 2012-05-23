using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Ciudad : DBable
    {
        public Ciudad(string Nombre, int PaisID)
        {
            this.Nombre = Nombre;
            this.PaisID = PaisID;
        }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Pais")]
        public int PaisID;




        public virtual Pais Pais { get; set; }
        public virtual ICollection<Provincia> Provincias { get; set; }
    }
}