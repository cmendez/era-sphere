using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaProveedores.Models
{
    public class LogicaProveedor:InterfazLogicaProveedor
    {
        ProveedorContext proveedor_context = new ProveedorContext();
        DBGenericQueriesUtil<Proveedor> database_table;
        DBGenericQueriesUtil<EstadoProveedor> table_estado;
        public LogicaProveedor() {
            database_table = new DBGenericQueriesUtil<Proveedor>( proveedor_context, proveedor_context.proveedores );
            table_estado = new DBGenericQueriesUtil<EstadoProveedor>(proveedor_context, proveedor_context.estados);
        }
        
        public List<Proveedor> retornarProveedores() {
            //return new List<Proveedor>() { new Proveedor{ ID=1 ,correo="jp@masmas.com" , direccion="Los Trolazos 123" , telefono = "188-ME-LACOMO" , razon_social = "Trolazos Inc." , ruc="1234567890" , persona_de_contacto = "DEGAY"} };
            return database_table.retornarTodos();
        }
        public Proveedor retornarProveedor(int proveedor_id) {
            return database_table.retornarUnSoloElemento(proveedor_id);
        }
        public void modificarProveedor(Proveedor proveedor) {
            int id = proveedor.estadoID;
            proveedor.estado = retornarEstado(id);
             database_table.modificarElemento(proveedor,proveedor.ID);
        }
        public void agregarProveedor(Proveedor proveedor) {
            int id = proveedor.estadoID;
            proveedor.estado = retornarEstado(id);
            database_table.agregarElemento(proveedor);
        }
        public void eliminarProveedor(int proveedor_id) {
            database_table.eliminarElemento(proveedor_id);
        }
        //revisar: "proveedor o no proveedor"
        public List<Proveedor> buscarProveedor(Proveedor proveedor) {
            return database_table.buscarElementos(proveedor);
        }
        public List<EstadoProveedor> retornarEstados() {
            return table_estado.retornarTodos();
        }
        public EstadoProveedor retornarEstado(int estado_id) {
            return table_estado.retornarUnSoloElemento(estado_id);
        }
    }   
}