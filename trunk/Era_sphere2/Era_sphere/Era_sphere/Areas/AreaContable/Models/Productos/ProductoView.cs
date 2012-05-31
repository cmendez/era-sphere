using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models.Productos
{
    public class ProductoView
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        
        [DisplayName("ID Moneda")]
        public int ID { get; set; }


        public ProductoView() { }
        
        public ProductoView(Producto producto) 
        {
            ID = producto.ID;
            Descripcion = producto.descripcion;
        }

        public Producto deserializa()
        {
            return new Producto
            {
                descripcion = this.Descripcion,
                ID = this.ID
            };
        }
    }
}