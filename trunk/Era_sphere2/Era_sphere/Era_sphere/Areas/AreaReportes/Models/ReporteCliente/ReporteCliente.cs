using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaReportes.Models.ReporteCliente
{
    public class ReporteCliente
    {
        public int estadoID { get; set; }
        public int tipo_documentoID { get; set; }
        public string tarjeta_cliente { get; set; }
        public string habitacion_asignada { get; set; }
        public int puntos_cliente { get; set; }
        public int numero_reservas { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string documento_identidad { get; set; }
        public string correo_electronico { get; set; }
        public string direccion { get; set; }
        public string ruc { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string razon_social { get; set; }
        public string usuario { get; set; }
        public int tipoID { get; set; }


        public ReporteCliente(string ruc, string documento_identidad, string usuario, string nombre, string razon_social, string tarjeta_cliente, string habitacion_asignada, int puntos_cliente, int numero_reservas)
        {
            this.ruc = ruc;
            this.documento_identidad = documento_identidad;
            this.usuario = usuario;
            this.nombre = nombre;
            this.razon_social = razon_social;
            this.tarjeta_cliente = tarjeta_cliente;
            this.habitacion_asignada = habitacion_asignada;
            this.puntos_cliente = puntos_cliente;
            this.numero_reservas = numero_reservas;

        }
    }
}