using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class Reserva : DBable, Costeable
    {
        [ForeignKey("estado")]
        public int estadoID { get; set; }
        public virtual EstadoReserva estado { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        public decimal costo_inicial { get; set; }

        public decimal precio_derecho_reserva { get; set; }

        public int num_habitaciones { get; set; }

        [ForeignKey("responsable_pago")]
        public int responsable_pagoID { get; set; }
        public virtual Cliente responsable_pago { get; set; }

        public DateTime dia_creacion = DateTime.Now;

        public decimal costo_final { get; set; }

        public int dias_estadia { get; set; }

        public int hotelID { get; set; }

        public int pisoID { get; set; }

        public string codigo_reserva
        {
            get
            {
                string res = "" + this.ID;
                while (res.Length < 6) res = "0" + res;
                return "R" + res;
            }
        }
        
        //Crea una nueva reserva y de paso crea el recibo que lo refiere y que es persiste aunque reserva muera
        public Reserva()
        {
            //LogicaRecibo log_rec = new LogicaRecibo();
            //reciboID = log_rec.nuevoRecibo();
        }



        public List<ReciboLinea> getReciboLineas()
        {
            throw new NotImplementedException();
        }

        public int getHotelID()
        {
            return hotelID;
        }

        public int getPagadorID()
        {
            return responsable_pagoID;
        }

        public void generaReciboLineas()
        {
            throw new NotImplementedException();
        }

        public void setEspacioRentableNombre()
        {
            throw new NotImplementedException();
        }

        public void getEspacioRentableNombre()
        {
            throw new NotImplementedException();
        }
    }
}