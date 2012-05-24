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
        
        [DisplayName("Detalle")]
        public string detalle { get; set; }

        [Required]
        [DisplayName("Piso")]
        public int pisoID { get; set; }

        [Required]
        [DisplayName("Capacidad de personas")]
        public int capacidad_maxima { get; set; }
        
        [DisplayName("Numero de niveles")]
        public int num_niveles { get; set; }
        
        [DisplayName("Estado")]
        public int estadoID { get; set; }

        public AmbienteView() { }

        public AmbienteView(Ambiente ambiente)
        {
            // TODO: Complete member initialization
            ID = ambiente.ID;
            nombre = ambiente.nombre;
            detalle = ambiente.detalle;
            pisoID = ambiente.pisoID;
            capacidad_maxima = ambiente.capacidad_maxima;
            estadoID = ambiente.estadoID;
        }

        public Ambiente deserializa(InterfazLogicaAmbiente logica)
        {
            return new Ambiente
            {
            ID = this.ID,
            nombre = this.nombre,
            detalle = this.detalle,
            pisoID = this.pisoID,
            capacidad_maxima = this.capacidad_maxima,
            estadoID = this.estadoID,
            };

        }

    }
}