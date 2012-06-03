using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class Pais: DBable
    {
        [Required]
        [MaxLength(30)]
        public string nombre { get; set; }

        [Range(0,100)]
        public double? IGV { get; set; }

        public virtual ICollection<Ciudad> ciudades { get; set; }

    }
}