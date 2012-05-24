using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaConfiguracion.Models;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class Provincia: DBable
    {
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Ciudad")]
        public int CiudadID { get; set; }



        public virtual Ciudad Ciudad { get; set; }
    }
}