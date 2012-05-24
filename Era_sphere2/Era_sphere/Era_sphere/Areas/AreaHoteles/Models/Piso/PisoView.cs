using System.ComponentModel;
//using Era_sphere.Areas.AreaHoteles.Models.;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class PisoView
    {
        public int ID { get; set; }

        //llega un hotel
        public int id_hotel { get; set; }

        [ReadOnly(true)]
        [DisplayName("Hotel")]
        public string nombre {
            get {
                //TODO
                return "";
                //LogicaHotel hoteles = new LogicaHotel();
                //return hoteles.retornarHotel(id_hotel).descripcion;
            }
        }


        [Required]
        [DisplayName("Código Piso")]
        [StringLength(50)]
        public string codigo_piso { get; set; }
        
        [Required]
        [DisplayName("Descripción")]
        [StringLength(50)]
        public string descripcion { get; set; }

        
        public PisoView() { }

        public PisoView(Piso piso)
        {
            // TODO: Complete member initialization
            ID = piso.ID;
            descripcion = piso.descripcion;
            codigo_piso = piso.codigo_piso;
            id_hotel = piso.hotel.ID;

        }

        public Piso deserializa(LogicaPiso logica)
        {
            return new Piso
            {
                //hotel_id= this.id_hotel,
                hotel = logica.context.hoteles.Find(this.id_hotel),
                hotelID = this.id_hotel,
                ID = this.ID,         
                descripcion = this.descripcion,
                codigo_piso = this.codigo_piso

            };

        }

    }
}