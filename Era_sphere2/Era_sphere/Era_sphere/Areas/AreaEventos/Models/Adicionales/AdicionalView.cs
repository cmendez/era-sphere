using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Era_sphere.Areas.AreaEventos.Models.Evento;

namespace Era_sphere.Areas.AreaEventos.Models.Adicionales
{
    public class AdicionalView
    {
        public AdicionalView() { }
        public AdicionalView(Adicional adicional)
        {
            ID = adicional.ID;
            nombre = adicional.nombre;
            precio= adicional.precio;
            eventoID = adicional.eventoID;
        }
        [Required]
        [MaxLength(30)]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        [Required]
        //falta limite
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [Required]
        [DisplayName("ID adicional")]
        public int ID { get; set; }
        [Required]
        [DisplayName("ID evento")]
        public int eventoID { get; set; }
        public Adicional deserializa()
        {
            return new Adicional
            {
                ID=this.ID,
                nombre=this.nombre,
                precio=this.precio,
                eventoID=this.eventoID
            };
        }
    }
}