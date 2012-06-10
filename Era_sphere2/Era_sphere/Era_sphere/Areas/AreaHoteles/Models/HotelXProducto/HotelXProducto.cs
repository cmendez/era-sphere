using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXProductoNM
{
    public class HotelXProducto : DBable
    {
        [Required]
        public int hotelID { get; set; }
        [Required]
        public int productoID { get; set; }
        [Required]
        public int monedaID { get; set; }
        [Required]
        public double precio { get; set; }
    }
}
