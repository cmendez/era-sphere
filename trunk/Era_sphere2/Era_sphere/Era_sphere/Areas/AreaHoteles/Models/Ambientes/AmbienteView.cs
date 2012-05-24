using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public class AmbienteView
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        
        [Required]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Piso")]
        public int pisoID { get; set; }
        public Piso piso { get; set; }

        [Required]
        [DisplayName("Capacidad de personas")]

        public int capacidad_personas { get; set; }
        
        [DisplayName("Numero de niveles")]
        public int num_niveles { get; set; }
        
        [DisplayName("Largo")]
        public int largo { get; set; }

        [DisplayName("Ancho")]
        public int ancho { get; set; }
    
        [DisplayName("Area")]
        public int area { get { return largo * ancho; } }

        [Required]
        [DisplayName("Hotel")]
        public int hotelID { get; set; }

        public AmbienteView() { }

        public AmbienteView(Ambiente ambiente)
        {
            // TODO: Complete member initialization
            ID = ambiente.ID;
            descripcion = ambiente.descripcion;
            pisoID = ambiente.pisoID;
            piso = ambiente.piso;
            capacidad_personas = ambiente.capacidad_personas;
            num_niveles = ambiente.num_niveles;
            largo = ambiente.largo;
            ancho = ambiente.ancho;
            hotelID = ambiente.hotelID;
        }

        public Ambiente deserializa(InterfazLogicaAmbiente logica)
        {
            return new Ambiente
            {
            ID = this.ID,
            descripcion = this.descripcion,
            pisoID = this.pisoID,
            piso = this.piso,
            capacidad_personas = this.capacidad_personas,
            num_niveles = this.num_niveles,
            largo = this.largo,
            ancho = this.ancho,
            hotelID = this.hotelID,
            };

        }

    }
}