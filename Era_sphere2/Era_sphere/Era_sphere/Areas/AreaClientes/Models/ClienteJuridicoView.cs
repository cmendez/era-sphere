using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class ClienteJuridicoView
    {

        public int ID { get; set; }

        //llega una habitacion

        [DisplayName("Estado")]
        public int id_estado { get; set; }

        [Required]
        [DisplayName("Tarjeta Cliente")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string tarjeta_cliente { get; set; }

 
        [DisplayName("Puntos Cliente")]
        [Range(0, StringsDeValidaciones.infinito)]
        public int puntos_cliente { get; set; }


        [Required]
        [DisplayName(@"Razón Social (*)")]
        [StringLength(100)]
        public string razon_social { get; set; }


        [DisplayName(@"Correo Electrónico")]
        [StringLength(100)]
        public string correo_electronico { get; set; }

        [DisplayName("Dirección")]
        [StringLength(100)]
        public string direccion { get; set; }

        [DisplayName(@"Teléfono")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string telefono { get; set; }

        [DisplayName("Celular")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string celular { get; set; }

        [DisplayName("Usuario")]
        [StringLength(50)]
        public string usuario { get; set; }

        [DisplayName("Password")]
        [StringLength(28)]
        public string contrasenha { get; set; }

        [Required]
        [DisplayName("RUC")]
        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string ruc { get; set; }

        [DisplayName(@"Pais")]
        public int paisID { get; set; }

        [DisplayName("Ciudad")]
        public int ciudadID { get; set; }

        //opcional
        //[DisplayName("Imagen")]

        [DisplayName(@"Reservas Históricas")]
        public int numero_reservas { get; set; }

        public ClienteJuridicoView() { }

        public ClienteJuridicoView(Cliente cliente)
        {
            // TODO: Complete member initialization
            ID = cliente.ID;
            razon_social = cliente.razon_social;
            ruc = cliente.ruc;
            correo_electronico = cliente.correo_electronico;
            telefono = cliente.telefono;
            celular = cliente.celular;
            direccion = cliente.direccion;
            usuario = cliente.usuario;
            contrasenha = cliente.password;
            id_estado = cliente.estadoID;
            ciudadID = cliente.ciudadID;
            paisID = cliente.paisID;
            puntos_cliente = cliente.puntos_cliente;
            numero_reservas = cliente.numero_reservas;
            tarjeta_cliente = cliente.tarjeta_cliente;
            //pais = logica.context_publico.paises.Find(this.paisID);



        }

        public Cliente deserializa(LogicaCliente logica)
        {
            return new Cliente
            {
                //hotel_id= this.id_hotel,
                ID = this.ID,
                razon_social = this.razon_social,
                ruc = this.ruc,
                correo_electronico = this.correo_electronico,
                telefono = this.telefono,
                celular = this.celular,
                direccion = this.direccion,
                usuario = this.usuario,
                password = this.contrasenha,
                estadoID = this.id_estado,
                estado = logica.context.estados_cliente.Find(this.id_estado),
                ciudadID = this.ciudadID,
                ciudad = logica.context.ciudades.Find(this.ciudadID),
                paisID = this.paisID,
                pais = logica.context.paises.Find(this.paisID),
                puntos_cliente = this.puntos_cliente,
                numero_reservas = this.numero_reservas,
                tarjeta_cliente = this.tarjeta_cliente,
                tipoID = 2,
                tipo = logica.context.tipos_personas.Find(2),
                tipo_documentoID = 3,
                tipo_documento = logica.context.tipos_documento.Find(3),
                //  habitacion_asignada =





            };

        }



    }
}