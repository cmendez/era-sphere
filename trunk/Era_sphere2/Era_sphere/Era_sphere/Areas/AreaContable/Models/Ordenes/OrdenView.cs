using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models.Ordenes
{
    public class OrdenView
    {
        private Orden o;

        public OrdenView()
        {
        }

        public OrdenView(Orden o)
        {
            ID = o.ID;

            switch (o.estado)
            {
                case 0: estado = "Registrado";              break;
                case 1: estado = "Parcialmente entregado";  break;
                case 2: estado = "Entregado";               break;
            }
            
            fechaRegistro = o.fechaRegistro;
            total = o.total;
            empleado_solicitaID = o.empleado_solicitaID;
            nro_lineas = o.nro_lineas;
        }

        public Orden deserealizar()
        {
            int e;
            switch (this.estado)
            {
                case "Registrado":              e = 0; break;
                case "Parcialmente entregado":  e = 1; break;
                case "Entregado":               e = 2; break;
            }

            return new Orden
            {
                ID = this.ID
            };
        }

        [Required]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        [DisplayName("N° talonario")]
        public int ntalonario { get; set; }

        public int? empleado_solicitaID { get; set; }

        [Required]
        public int estadoID { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }

        [DisplayName("Fecha registro")] 
        public DateTime fechaRegistro { get; set; }

        [DisplayName("N° lineas")]
        public int nro_lineas { get; set; }

        [DisplayName("Total ($)")]
        public double total { get; set; }
    }
}