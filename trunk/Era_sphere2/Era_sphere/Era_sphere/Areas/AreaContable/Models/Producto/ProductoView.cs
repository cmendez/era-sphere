using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ProductoView
    {
        public ProductoView() { }
        public ProductoView(Producto producto)
        {
            ID = producto.ID;
            descripcion = producto.descripcion;
        }
        [Required]
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("ID Tipo de Pago")]
        public int ID { get; set; }
        public Producto deserializa(InterfazLogicaProducto logica)
        {
            return new Producto
            {
                descripcion = this.descripcion,
                ID = this.ID,
            };
        }
    }
}