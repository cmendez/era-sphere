using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class ClienteNaturalView
    {

        public int ID { get; set; }
        
        //llega una habitacion
        [DisplayName("Habitación Asignada")]
        public int id_habitacion { get; set; }
        
        [DisplayName("Estado")]
        public int id_estado { get; set; }
        
        [Required]
        [DisplayName("Tarjeta Cliente")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string tarjeta_cliente { get; set; }
        
    
        [DisplayName("Puntos Cliente")]
        [Range(0,StringsDeValidaciones.infinito)]
        public int puntos_cliente { get; set; }
        
        [Required]
        [DisplayName("Nombre (*)")]
        [StringLength(50)]
        public string nombre {get; set;}

        [Required]
        [DisplayName("Apellido Paterno (*)")]
        [StringLength(28)]
        public string apellido_paterno {get; set;}

        [Required]
        [DisplayName("Apellido Materno (*)")]
        [StringLength(28)]
        public string apellido_materno {get; set;}
        
        [Required]
        [DisplayName("Documento Identidad (*)")]
        [StringLength(28)]
        public string documento_identidad {get; set;}

        [DisplayName(@"Correo Electrónico")]
        [StringLength(100)]
        public string correo_electronico { get; set; }

        [DisplayName("Dirección")]
        [StringLength(100)]
        public string direccion {get; set;}

        [DisplayName(@"Teléfono")]
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
        

        [DisplayName(@"Pais")]
        public int paisID { get; set; }

        [DisplayName("Ciudad")]
        public int ciudadID { get; set; }

        //opcional
        //[DisplayName("Imagen")]

        //[DisplayName(@"Reservas Históricas")]
        //public int numero_reservas { get; set; }
        
        public ClienteNaturalView() { }

        public ClienteNaturalView(Cliente cliente)
        {
            // TODO: Complete member initialization
            ID = cliente.ID;
            nombre = cliente.nombre;
            apellido_paterno = cliente.apellido_paterno;
            apellido_materno = cliente.apellido_materno;
            documento_identidad = cliente.documento_identidad;
            ruc = cliente.ruc;
            correo_electronico = cliente.correo_electronico;
            telefono = cliente.telefono;
            celular = cliente.celular;
            fecha_nacimiento = cliente.fecha_nacimiento;
            direccion = cliente.direccion;
            usuario = cliente.usuario;
            contrasenha = cliente.password;
            id_habitacion = cliente.id_habitacion_asisgnada;  
            ciudadID = cliente.ciudadID;
            paisID = cliente.paisID;
            puntos_cliente = cliente.puntos_cliente;
            tarjeta_cliente = cliente.tarjeta_cliente;
            id_estado = cliente.estadoID;
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
                    documento_identidad = this.documento_identidad,
                    ruc = this.ruc,
                    correo_electronico = this.correo_electronico,
                    telefono = this.telefono,
                    celular = this.celular,
                    fecha_nacimiento = this.fecha_nacimiento,
                    direccion = this.direccion,
                    usuario = this.usuario,
                    password = this.contrasenha,
                    id_habitacion_asisgnada = this.id_habitacion,
                    ciudadID = this.ciudadID,
                    ciudad = logica.cliente_context.ciudades.Find(this.ciudadID),
                    paisID = this.paisID,
                    pais = logica.cliente_context.paises.Find(this.paisID),
                    puntos_cliente = this.puntos_cliente,
                    tarjeta_cliente = this.tarjeta_cliente,
                    
                    estadoID = this.id_estado,
                    estado = logica.cliente_context.estados_cliente.Find(this.id_estado),
                    tipoID = 1,
                    tipo = logica.cliente_context.tipos_personas.Find(1),
                  //  habitacion_asignada =
                 

               
          

            };

        }



    }
}