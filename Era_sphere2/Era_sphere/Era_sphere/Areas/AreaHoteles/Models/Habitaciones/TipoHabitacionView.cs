using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacionView
    {
        public TipoHabitacionView() { }
        public TipoHabitacionView(TipoHabitacion tipoHabitacion, int hotelID = 0)
        {
            costo_base = tipoHabitacion.costo_base;
            descripcion = tipoHabitacion.descripcion;
            cap_max_personas = tipoHabitacion.cap_max_personas;
            ID = tipoHabitacion.ID;
            this.hotelID = hotelID;
            numero_camas = tipoHabitacion.numero_camas;
        }
        [Required]
        [DisplayName("Descripcion")]
        [StringLength(30)]
        public string descripcion { get; set; }
        [DisplayName("Capacidad maxima")]
        [Range(1, 20)]
        public int cap_max_personas { get; set; }
        [DisplayName("ID tipo habitacion")]
        public int ID { get; set; }
        [DisplayName("Costo base")]
        [Range(0, Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal costo_base { get; set; }

        public int hotelID {get; set;}
        public int numero_camas { get; set; }
        [DisplayName("Precio por noche")]
        public decimal costo
        {
            get
            {
                if (ID == 0) return 0;
                LogicaHotelXTipoHabitacionXTemporada logica = new LogicaHotelXTipoHabitacionXTemporada();
                return logica.getPrecioTipoHabitacion(hotelID, ID, DateTime.Now);
            }
        }

        public string[] comodidades_descripcion { get; set; }
        public int[] comodidades_id { get; set; }
        public TipoHabitacion deserializa(LogicaTipoHabitacion logica)
        {

            TipoHabitacion tipo_habitacion = new TipoHabitacion
            {
                descripcion = this.descripcion,
                cap_max_personas = this.cap_max_personas,
                ID = this.ID
            };

            //for (int i = 0; i<comodidades_id.Length; i++)
            //{
            //    tipo_habitacion.comodidades=(new Era_sphere)
            //}
            return tipo_habitacion;
        }
    }
}