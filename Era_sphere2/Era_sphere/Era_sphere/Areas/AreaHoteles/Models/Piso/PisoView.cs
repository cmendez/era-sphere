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
        public string nombre_hotel { get; set; }


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
            nombre_hotel = piso.hotel_nombre;
            id_hotel = piso.hotel_id;

        }

        public Piso deserializa(InterfazLogicaPiso logica)
        {
            return new Piso
            {
                hotel_id= this.id_hotel,
                hotel_nombre = this.nombre_hotel,
                ID = this.ID,         
                descripcion = this.descripcion,
                numero_piso = this.numero_piso

            };

        }

    }
}