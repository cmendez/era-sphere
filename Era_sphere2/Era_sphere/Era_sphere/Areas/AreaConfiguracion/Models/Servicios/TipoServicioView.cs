using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class TipoServicioView
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Tiene productos asociados")]
        public bool tiene_productos_asociados { get; set; }
        [Required]
        [DisplayName("Se desarrolla en una hora fija")]
        public bool tiene_hora { get; set; }
        [Required]
        [DisplayName("Puede admitir repeticiones")]
        public bool tiene_repeticiones { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        public TipoServicioView(TipoServicio tipo)
        {
            this.ID = tipo.ID;
            this.tiene_hora = tipo.tiene_hora;
            this.tiene_productos_asociados = tipo.tiene_productos_asociados;
            
        }
    }
}