using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class Moneda:DBable
    {
        public Moneda() { }        
        
        [DisplayName("Descripcion")]
        public string moneda_descripcion { get; set; }

        [DisplayName("Simbolo")]
        public string simbolo { get; set; }

        [DisplayName("IdPais")]
        public int idPais { get; set; }

        public Pais pais { set; get; }
    }
}