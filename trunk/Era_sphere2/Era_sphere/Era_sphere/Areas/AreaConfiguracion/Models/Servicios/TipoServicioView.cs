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
        
        [DisplayName("Puede admitir repeticiones")]
        public bool tiene_repeticiones { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Campo Adicional 1")]
        public string campo1 { get; set; }
        [DisplayName("Campo Adicional 2")]
        public string campo2 { get; set; }
        [DisplayName("Campo Adicional 3")]
        public string campo3 { get; set; }

        public decimal precio_normal { get; set; }
        public TipoServicioView(TipoServicio tipo)
        {
            this.ID = tipo.ID;
            this.tiene_productos_asociados = tipo.tiene_productos_asociados;
            this.tiene_repeticiones = tipo.tiene_repeticiones;
            this.nombre = tipo.nombre;
            this.descripcion = tipo.descripcion;
            this.campo1 = tipo.campo1;
            this.campo2 = tipo.campo2;
            this.campo3 = tipo.campo3;
        }
        public TipoServicioView(){}

        public TipoServicio deserializa(LogicaServicios logica)
        {
            return new TipoServicio
            {
                ID = this.ID,
                tiene_repeticiones = this.tiene_repeticiones,
                tiene_productos_asociados = this.tiene_productos_asociados,
                nombre = this.nombre,
                descripcion = this.descripcion,
                campo1 = this.campo1 ?? "",
                campo2 = this.campo2 ?? "",
                campo3 = this.campo3 ?? "",
            
            };
        }
    }
}