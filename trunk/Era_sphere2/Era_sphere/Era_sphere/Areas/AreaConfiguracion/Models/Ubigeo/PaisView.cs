using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo
{
    public class PaisView
    {

        public PaisView() { }
        public PaisView(Pais pais)
        {
            this.ID = pais.ID;
            this.Nombre = pais.nombre;
            this.IGV = pais.IGV;
        }

        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("IGV (%)")]
        [Range(0, 100)]
        public double? IGV { get; set; }


        public Pais deserializa()
        {
            return new Pais
            {
                ID = this.ID,
                nombre = this.Nombre,
                IGV = this.IGV
            };
        }
    }
}