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
        public string nombre_hotel {
            get {
                //TODO
                return "";
                //LogicaHotel hoteles = new LogicaHotel();
                //return hoteles.retornarHotel(id_hotel).descripcion;
            }
        }


        [Required]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Numero Piso")]
        public int numero_piso { get; set; }
        public PisoView() { }

        public PisoView(Piso piso)
        {
            // TODO: Complete member initialization
            ID = piso.ID;
            descripcion = piso.descripcion;
            numero_piso = piso.numero_piso;
            id_hotel = piso.hotel_id;

        }

        public Piso deserializa(InterfazLogicaPiso logica)
        {
            return new Piso
            {
                hotel_id= this.id_hotel,
                ID = this.ID,         
                descripcion = this.descripcion,
                numero_piso = this.numero_piso

            };

        }

    }
}