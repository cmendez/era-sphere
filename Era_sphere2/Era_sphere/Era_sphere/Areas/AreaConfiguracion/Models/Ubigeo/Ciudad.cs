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
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Required]
        [ForeignKey("Pais")]
        public int paisID;

        public virtual Pais pais { get; set; }
        public virtual ICollection<Provincia> provincias { get; set; }
    }
}