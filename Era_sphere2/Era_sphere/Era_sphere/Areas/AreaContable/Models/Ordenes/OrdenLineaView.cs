using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class OrdenLineaView
    {
        public OrdenLineaView()
        {

        }

        public OrdenLineaView(OrdenLinea o)
        {


        }

        public OrdenLinea deserealizar(int ordenID)
        {
            proveedor_x_producto pxp = (new EraSphereContext()).p_x_p.Single(pxp1 => pxp1.productoID == productoID && pxp1.proveedorID == proveedorID);

            return new OrdenLinea
            {
                ID = ID,
                ordenID = ordenID,
                producto_x_proveedorID = pxp.ID,
                precioU = pxp.precio_unitario,
                cantidad = cantidad,
                SubTotal = pxp.precio_unitario*cantidad
            };
        }


        [Required]
        public int ID {get; set;}

        [Required]
        [DisplayName("Proveedor")]
        public int proveedorID {get; set;}
        [Required]
        [DisplayName("Producto")]
        public int productoID {get; set;}

        [Required]
        [Range(1,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public int cantidad {get; set;}

        //[Required]
        //[Range(9, Era_sphere.Generics.StringsDeValidaciones.infinito)]
        [DisplayName("Precio unitario ($)")]
        public decimal precioFacturado { get; set; }



        [DisplayName("Proveedor")]
        public string razon_social_prov {get; set;}

        [DisplayName("Producto")]
        public string producto_desc {get; set;}

    }
}


        //[ForeignKey("proveedor_x_producto")]
        //public int producto_x_proveedorID { get; set; }

        //public virtual proveedor_x_producto proveedor_x_producto { get; set; }

        //public double precioU { get; set; }
        //public double cantidad { get; set; }
        //public double SubTotal { get; set; }
        //public int estado { get; set; } // 1 Pendiente 2 Parcial 3 Total 4 cancel
        ////public DateTime fechaentrega { get; set; }

        
        
        //[ForeignKey("orden")]
        //public int ordenID  { get; set; }

        //public Orden orden { get; set; }