using System.ComponentModel;
//using Era_sphere.Areas.AreaHoteles.Models.;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class PisoView
    {
        public int ID { get; set; }

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

        }

        public Piso deserializa(InterfazLogicaPiso logica)
        {
            return new Piso
            {
                ID = this.ID,         
                descripcion = this.descripcion,
                numero_piso = this.numero_piso

            };

        }

    }
}