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
        public string habitacion_asignada { get; set; }
        //public int id_habitacion_asignada { get; set; }
        
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
        [StringLength(30)]
        public string apellido_paterno {get; set;}

        [Required]
        [DisplayName("Apellido Materno (*)")]
        [StringLength(30)]
        public string apellido_materno {get; set;}

        [DisplayName("Tipo Documento")]
        public int id_tipo_documento { get; set; }

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
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string telefono {get; set;}

        [DisplayName("Celular")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string celular {get; set;}

        [Required]
        [DisplayName("Usuario")]
        [StringLength(28)]
        public string usuario { get; set;}

        [Required]
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
        //[Required(ErrorMessage="Especifique un pais")]
        public int paisID { get; set; }

        [DisplayName("Ciudad")]
        //[Required]
        //[Range(1, 1000000, ErrorMessage="Especifique una ciudad")]
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
            habitacion_asignada = cliente.habitacion_asignada;
            
            ciudadID = cliente.ciudadID;
            paisID = cliente.paisID;
            puntos_cliente = cliente.puntos_cliente;
            tarjeta_cliente = cliente.tarjeta_cliente;
            id_estado = cliente.estadoID;
            id_tipo_documento = cliente.tipo_documentoID;
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
                    habitacion_asignada = this.habitacion_asignada,
                    //id_habitacion_asisgnada = this.id_habitacion,
                    ciudadID = this.ciudadID,
                    ciudad = logica.context.ciudades.Find(this.ciudadID),
                    paisID = this.paisID,
                    pais = logica.context.paises.Find(this.paisID),
                    puntos_cliente = this.puntos_cliente,
                    tarjeta_cliente = this.tarjeta_cliente,
                    
                    estadoID = this.id_estado,
                    estado = logica.context.estados_cliente.Find(this.id_estado),

                    tipo_documentoID=this.id_tipo_documento,
                    tipo_documento = logica.context.tipos_documento.Find(this.id_tipo_documento),
                    
                    tipoID = 1,
                    tipo = logica.context.tipos_personas.Find(1),
                  //  habitacion_asignada =
                 

               
          

            };

        }



    }
}