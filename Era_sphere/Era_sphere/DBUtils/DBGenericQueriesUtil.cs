using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;

namespace Era_sphere.DBUtils
{
    public class  DBGenericQueriesUtil <T> where T : DBable
    {
        DbSet<T> dbset;
        DbContext context;

        public DBGenericQueriesUtil(DbContext context, DbSet<T> dbset){
            this.context = context;
            this.dbset = dbset;
        }
        
        public List<T> retornarTodos()
        {
            return dbset.ToList();
        }
        
        public T retornarUnSoloElemento(int ID)
        {
            return dbset.Find(ID);
        }
        
        public void modificarElemento(T elemento, int ID)
        {
            var elemento_db = dbset.Find(ID);
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(elemento))
            {
                if (property.GetValue(elemento) != null)
                {
                    property.SetValue(elemento_db, property.GetValue(elemento));
                }
            }
            context.Entry(elemento_db).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void agregarElemento(T elemento){
            elemento.ID = dbset.Max(p => p.ID) + 1;
            dbset.Add(elemento);
            context.SaveChanges();
        }

        public void eliminarElemento(int ID)
        {
            var elemento_a_eliminar = dbset.Find(ID);
            if(elemento_a_eliminar != null)
            {
                dbset.Remove(elemento_a_eliminar);
                context.SaveChanges();
            }
        }
}