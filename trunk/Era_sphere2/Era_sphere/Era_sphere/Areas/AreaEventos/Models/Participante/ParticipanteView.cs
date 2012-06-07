using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaEventos.Models.Participante
{
    public class ParticipanteView
    {
        public ParticipanteView() { }
        public ParticipanteView(Participante participante)
        {
            ID = participante.ID;
            nombre = participante.nombre;
            dni = participante.dni;
            eventoID = participante.eventoID;
        }
        [Required]
        [MaxLength(30)]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        [Required]
        //falta limite
        [DisplayName("Dni")]
        public string dni{ get; set; }
        [Required]
        [DisplayName("ID Participante")]
        public int ID { get; set; }
        [Required]
        [DisplayName("ID evento")]
        public int eventoID { get; set; }
        public Participante deserializa()
        {
            return new Participante
            {
                ID=this.ID,
                nombre=this.nombre,
                dni=this.dni,
                eventoID=this.eventoID
            };
        }
    }
}