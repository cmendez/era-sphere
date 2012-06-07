using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados;



namespace Era_sphere.Areas.AreaEmpleados.Models.AsistenciaEmpleados
{
    public class AsistenciaEmpleadoView : IValidatableObject
    {
        public int ID { get; set; }

        [DisplayName("Codigo Empleado")]
        public string empleadoID { get; set; }
        [DisplayName("Fecha y hora de entrada")]
        public DateTime? fechaHoraEntrada { get; set; }
        [DisplayName("Fecha y hora de entrada")]
        public DateTime? fechaHoraSalida { get; set; }
        [DisplayName("Asistencia")]
        public string s_asistencia { get; set; }





        public AsistenciaEmpleadoView() { }

        public AsistenciaEmpleadoView(AsistenciaEmpleado asistencia)
        {
            // TODO: Complete member initialization
            ID = asistencia.ID;
            empleadoID = asistencia.empleadoID;
            fechaHoraEntrada = asistencia.fechaHoraEntrada;
            fechaHoraSalida = asistencia.fechaHoraSalida;
            s_asistencia = asistencia.s_asistencia;

        }

        /*public Promocion deserializa(LogicaPromocion logica)
        {
            return new Promocion
            {
                ID = this.ID,
                nombre = this.nombre,
                descripcion = this.descripcion,
                puntos_requeridos = this.puntos_requeridos,
                descuento = this.descuento,
                fecha_inicio = this.fecha_inicio,
                fecha_fin = this.fecha_fin,
            };

        }*/

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            return null;
        }

    }
}