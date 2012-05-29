using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaClientes.Models
{
    
        public class Cliente : Persona
        {

            public Cliente() 
            {
                //estado = EstadoCliente.sin_reserva;
                //tipo = TipoCliente.natural;
            }

  //        [ForeignKey("Estado")]
            public int estadoID { get; set; }
            public virtual EstadoCliente estado { get; set; }

//          [DisplayName("Tarjeta cliente")]
            public string tarjeta_cliente { get; set; }

            public Habitacion habitacion_asignada { get; set; }
            public int id_habitacion_asisgnada { get; set; }
            public int puntos_cliente { get; set; }


            public int ciudadID { get; set; }
        }



}