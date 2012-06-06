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
        [DisplayName("Tiene productos asociados")]
        public bool tiene_productos_asociados { get; set; }
        
        [DisplayName("Se desarrolla en una hora fija")]
        public bool tiene_hora { get; set; }
        
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
            this.tiene_repeticiones = tipo.tiene_repeticiones;
            this.nombre = tipo.nombre;
            this.descripcion = tipo.descripcion;
        }
        public TipoServicioView(){}

        public TipoServicio deserializa(LogicaServicios logica)
        {
            return new TipoServicio
            {
                ID = this.ID,
                tiene_hora = this.tiene_hora,
                tiene_repeticiones = this.tiene_repeticiones,
                tiene_productos_asociados = this.tiene_productos_asociados,
                nombre = this.nombre,
                descripcion = this.descripcion,
            };
        }
    }
}