using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class Evento : DBable, Costeable
    {
        #region atributos
        public DateTime fecha_inicio { get; set; }
        
        public string nombre { get; set; }

        public string dni { get; set; }

        public decimal precio_total { get; set; }
        
        public int num_participantes { get; set; }

        //[ForeignKey("hotel")]
        public int hotel { get; set; }
        //[Required]
        //public virtual Hotel hotel { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente> eventoXAmbiente { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.Participante.Participante> participantes { get; set; }

        public virtual ICollection<Adicional> adicionales { get; set; }
        
        public int estado_eventoID { get; set; }
        
        //[ForeignKey("cliente_evento")]
        //public int cliente_eventoID { get; set; }
        //public virtual Cliente cliente_evento { get; set; }
        ////[ForeignKey("cliente")]
        public string detalle { get; set; }

        public virtual ICollection<Servicio> evento_servicios { get; set; }
        //public virtual Cliente cliente { get; set; }

        #endregion

        public List<ReciboLinea> getReciboLineas()
        {
            return new List<ReciboLinea>();
        }
        public void registraReciboLinea(ReciboLinea r)
        {

        }
        public int getHotelID()
        {
            return 1;
        }
        public int getPagadorID()
        {
            return 2;
        }
        public void generaReciboLineas()
        {

        }
        public void setEspacioRentableNombre(string s)
        {

        }
        public string getEspacioRentableNombre()
        {
            return "gg";
        }
    }
}