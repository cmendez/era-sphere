using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaEmpleados.Models
{
    public class EmpleadoView
    {
        public int ID { get; set; }

        
        public string nombre_cargo { get; set; }
        public string estado { get; set; }
        public string cad_horario {get; set; }
        public string cad_horasIn {get; set; }
        public string cad_horasOut {get; set; }
        public string sueldo { get; set; }


        //persona
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }

        public string apellido_materno { get; set; }

        public string documento_identidad { get; set; }

        public string correo_electronico { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string celular { get; set; }

        public string usuario { get; set; }

        public string contrasenha { get; set; }

     
        public DateTime? fecha_nacimiento { get; set; }


        public int paisID { get; set; }

        public int ciudadID { get; set; }

        public EmpleadoView() { }

        public EmpleadoView(Empleado empleado)
        {
            // TODO: Complete member initialization
            ID = empleado.ID;

            nombre_cargo = empleado.nombre_cargo;
            estado = empleado.estado;
            cad_horario = empleado.cad_horario;
            cad_horasIn = empleado.cad_horasIn;
            cad_horasOut = empleado.cad_horasOut;
            sueldo = empleado.sueldo;

            nombre = empleado.nombre;
            apellido_paterno = empleado.apellido_paterno;
            apellido_materno = empleado.apellido_materno;
            documento_identidad = empleado.documento_identidad;

            correo_electronico = empleado.correo_electronico;
            telefono = empleado.telefono;
            celular = empleado.celular;
            fecha_nacimiento = empleado.fecha_nacimiento;
            direccion = empleado.direccion;
            usuario = empleado.usuario;
            contrasenha = empleado.password;

            ciudadID = empleado.ciudadID;
            paisID = empleado.paisID;
         
        }

        public Empleado deserializa(LogicaEmpleado logica)
        {
            return new Empleado
            {
                //hotel_id= this.id_hotel,
                ID = this.ID,
                nombre_cargo = this.nombre_cargo,
                estado = this.estado,
                cad_horario = this.cad_horario,
                cad_horasIn = this.cad_horasIn,
                cad_horasOut = this.cad_horasOut,
                sueldo = this.sueldo,
                
                nombre = this.nombre,
                apellido_paterno = this.apellido_paterno,
                apellido_materno = this.apellido_materno,
                documento_identidad = this.documento_identidad,
                
                correo_electronico = this.correo_electronico,
                telefono = this.telefono,
                celular = this.celular,
                fecha_nacimiento = this.fecha_nacimiento,
                direccion = this.direccion,
                usuario = this.usuario,
                password = this.contrasenha,
                
                ciudadID = this.ciudadID,
                ciudad = logica.empleado_context.ciudades.Find(this.ciudadID),
                paisID = this.paisID,
                pais = logica.empleado_context.paises.Find(this.paisID),

                tipoID = 1,
                tipo = logica.empleado_context.tipos_personas.Find(1),
                //  habitacion_asignada =
            };

        }

    }

       

}