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
            EraSphereContext context = new EraSphereContext();
            List<Servicio> servicios = context.servicioxreservas.Where(x => x.reservaID == ID).Select(y => context.servicios.Find(y.servicioID)).ToList();
            List<ReciboLinea> lineas = context.recibos_linea_x_reserva.Where(x => x.reservaID == ID).Select(y => context.recibos_lineas.Find(y.recibo_lineaID)).ToList();
            foreach (var s in servicios)
            {
                List<ReciboLinea> lineas2 = s.getReciboLineas();
                lineas2.ForEach(x => x.detalle = "   " + x.detalle);
                lineas.AddRange(lineas2);
            }
            return lineas;
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
            if (precio_derecho_reserva > 0)
            {
                ReciboLinea paguito = new ReciboLinea("Pago del adelanto", precio_derecho_reserva, 1, DateTime.Now, false);
                registraReciboLinea(paguito);
            }
        }

     
        public string getEspacioRentableNombre()
        {
            EraSphereContext context = new EraSphereContext();
            return context.hoteles.Find(hotelID).descripcion;
        }

        public void registraReciboLinea(ReciboLinea linea)
        {
            EraSphereContext context = new EraSphereContext();
            context.recibos_lineas.Add(linea);
            context.SaveChanges();
            ReciboLineaXReserva x = new ReciboLineaXReserva { recibo_lineaID = linea.ID, reservaID = ID };
            context.recibos_linea_x_reserva.Add(x);
            context.SaveChanges();
        }


        public void setEspacioRentableNombre(string s)
        {
            throw new NotImplementedException();
        }

    }
}