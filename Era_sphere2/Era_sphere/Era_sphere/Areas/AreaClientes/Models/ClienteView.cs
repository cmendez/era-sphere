using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class ClienteView
    {

        public int ID { get; set; }

        //llega una habitacion
        [DisplayName("Habitación Asignada")]
        public int id_habitacion { get; set; }

        [DisplayName("Estado")]
        public EstadoCliente id_estado { get; set; }

        [Required]
        [DisplayName("Tarjeta Cliente")]
        [StringLength(30)]
        public string tarjeta_cliente { get; set; }
        
        [Required]
        [DisplayName("Puntos Cliente")]
        [Range(0,StringsDeValidaciones.infinito)]
        public int puntos_cliente { get; set; }

        [Required]
        [DisplayName("Nombre (*)")]
        [StringLength(50)]
        public string nombre {get; set;}

        [Required]
        [DisplayName("Razón Social (*)")]
        [StringLength(100)]
        public string razon_social { get; set;}

        [Required]
        [DisplayName("Apellido Paterno (*)")]
        [StringLength(28)]
        public string apellido_paterno {get; set;}

        [Required]
        [DisplayName("Apellido Materno (*)")]
        [StringLength(28)]
        public string apellido_materno {get; set;}
        
        [Required]
        [DisplayName("DNI (*)")]
        [StringLength(28)]
        public string dni {get; set;}

        [Required]
        [DisplayName("Pasaporte (*)")]
        [StringLength(28)]
        public string pasaporte {get; set;}

        [DisplayName("Correo Electrónico")]
        [StringLength(100)]
        public string correo_electronico { get; set; }

        [DisplayName("Dirección")]
        [StringLength(100)]
        public string direccion {get; set;}

        [DisplayName("Teléfono")]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string telefono {get; set;}

        [DisplayName("Celular")]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string celular {get; set;}

        [DisplayName("Usuario")]
        [StringLength(50)]
        public string usuario { get; set;}

        [DisplayName("Password")]
        [StringLength(28)]
        public string contrasenha { get; set; }

        [DisplayName("RUC")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string ruc { get; set; }

        //alguna validación
        [DisplayName("Fecha Nacimiento")]
        public DateTime? fecha_nacimiento { get; set; }


        [Required]
        [DisplayName("Pais")]
        public int paisID { get; set; }

        [Required]
        [DisplayName("Ciudad")]
        public int ciudadID { get; set; }


        [Required]
        [DisplayName("Tipo de persona")]
        public Cliente.TipoPersona tipo { get; set; }
        //opcional
        //[DisplayName("Imagen")]
        
        public ClienteView() { }

        public ClienteView(Cliente cliente)
        {
            // TODO: Complete member initialization
            ID = cliente.ID;
            nombre = cliente.nombre;
            apellido_paterno = cliente.apellido_paterno;
            apellido_materno = cliente.apellido_materno;
            razon_social = cliente.razon_social;
            dni = cliente.dni;
            ruc = cliente.ruc;
            pasaporte = cliente.pasaporte;
            correo_electronico = cliente.correo_electronico;
            telefono = cliente.telefono;
            celular = cliente.celular;
            fecha_nacimiento = cliente.fecha_nacimiento;
            direccion = cliente.direccion;
            usuario = cliente.usuario;
            contrasenha = cliente.password;
            id_habitacion = cliente.id_habitacion_asisgnada;
            id_estado = cliente.estado;
            ciudadID = cliente.ciudadID;
            paisID = cliente.paisID;
            puntos_cliente = cliente.puntos_cliente;
            //pais = logica.context_publico.paises.Find(this.paisID);

           

        }

        public Cliente deserializa(LogicaCliente logica)
        {
            return new Cliente
            {
                //hotel_id= this.id_hotel,
                    ID = this.ID,
                    nombre = this.nombre,
                    apellido_paterno = this.apellido_paterno,
                    apellido_materno = this.apellido_materno,
                    razon_social = this.razon_social,
                    dni = this.dni,
                    ruc = this.ruc,
                    pasaporte = this.pasaporte,
                    correo_electronico = this.correo_electronico,
                    telefono = this.telefono,
                    celular = this.celular,
                    fecha_nacimiento = this.fecha_nacimiento,
                    direccion = this.direccion,
                    usuario = this.usuario,
                    password = this.contrasenha,
                    id_habitacion_asisgnada = this.id_habitacion,
                    estado = this.id_estado,
                    //dude
                    ciudadID = this.ciudadID,
                    //dude
                    paisID = this.paisID,
                    pais = logica.cliente_context.paises.Find(this.paisID),
                    puntos_cliente = this.puntos_cliente,
                  //  habitacion_asignada =
                   // pais =
                   // ciudad =

               
          

            };

        }



    }
}