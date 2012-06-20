using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class ComboEntregaItem
    {

        public ComboEntregaItem(OCompraLinea item)
        {
            descripcion = String.Format("{0}|{1,100}|{2,10}|{3,10}", 
                            item.producto.ID, item.producto.producto.descripcion.PadRight(100),
                            item.cantidad, item.cantidad_recibida);
            ID = item.ID;
        }
        public string descripcion { get; set; }
        public int ID { get; set; }
    }
}
