using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public class AmbienteView
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string nombre { get; set; }
        
        [DisplayName("Detalle")]
        [StringLength(50)]
        public string detalle { get; set; }

        [Required]
        [DisplayName("Piso")]
        public int pisoID { get; set; }

        [Required]
        [DisplayName("Capacidad de personas")]
        [Range(0, StringsDeValidaciones.infinito)]
        public int capacidad_maxima { get; set; }
        
        [DisplayName("Numero de niveles")]
        [Range(0, 3)]
        public int num_niveles { get; set; }
        
        [DisplayName("Estado")]
        public int estadoID { get; set; }

        [Required]
        [DisplayName("Alquiler (x hora) ($)")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }

        public AmbienteView() { }

        public AmbienteView(Ambiente ambiente)
        {
            // TODO: Complete member initialization
            ID = ambiente.ID;
            nombre = ambiente.descripcion;
            detalle = ambiente.detalle;
            pisoID = ambiente.pisoID;
            capacidad_maxima = ambiente.capacidad_maxima;
            estadoID = ambiente.estadoID;
            num_niveles = ambiente.num_niveles;
            precio = ambiente.precio;
        }

        public Ambiente deserializa(InterfazLogicaAmbiente logica)
        {
            return new Ambiente
            {
            ID = this.ID,
            descripcion = this.nombre,
            detalle = this.detalle,
            pisoID = this.pisoID,
            piso = logica.context_publico.pisos.Find(pisoID),
            capacidad_maxima = this.capacidad_maxima,
            estadoID = this.estadoID,
            estado = logica.context_publico.estado_espacio_rentable.Find(estadoID),
            num_niveles = this.num_niveles,
            precio = this.precio
            };

        }

    }
}