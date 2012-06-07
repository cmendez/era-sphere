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
        public int ID { get; set; }

        public int empleado_solicitaID { get; set; }

        [Required]
        public string estado { get; set; }

        public DateTime fechaRegistro { get; set; }

        public decimal total { get; set; }
    }
}