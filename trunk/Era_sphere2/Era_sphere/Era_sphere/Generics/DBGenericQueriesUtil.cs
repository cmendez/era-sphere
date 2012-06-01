using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Era_sphere.Generics
{
    public class DBGenericQueriesUtil<T> where T : DBable
    {
        DbSet<T> dbset;
        DbContext context;

        public DBGenericQueriesUtil(DbContext context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;

        }

        public List<T> retornarTodos()
        {
            var res = dbset.ToList();
            if (res == null) return new List<T>();
            else return res;
        }

        public T retornarUnSoloElemento(int ID)
        {
            try
            {
                return dbset.Find(ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void modificarElemento(T elemento, int ID)
        {
            var elemento_db = dbset.Find(ID);
            if (elemento_db == null) throw new Exception("No existe el ID en la BD");
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

        public void agregarElemento(T elemento)
        {
            if (elemento.ID == 0)
            {
                var todos = (from u in dbset select u.ID).ToList();
                int maxi = todos.Count > 0 ? todos.Max() : 0;
                elemento.ID = maxi + 1;
            }
            
            dbset.Add(elemento);
            context.SaveChanges();
        }

        public void eliminarElemento(int ID)
        {
            var elemento_a_eliminar = dbset.Find(ID);
            if (elemento_a_eliminar == null) throw new Exception("No existe el ID en la BD");
            dbset.Remove(elemento_a_eliminar);
            context.SaveChanges();
        }

        public List<T> buscarElementos(T elemento_campos)
        {
            string where = string.Empty;
            bool first_line = true;
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(elemento_campos))
            {
                if (property.GetValue(elemento_campos) != null)
                {
                    var value = property.GetValue(elemento_campos);
                    if (first_line)
                        first_line = false;
                    else where += " And ";
                    if (property.GetType() == where.GetType()) //query de un string
                        where += property.Name + ".StartsWith(\"" + (string)value + "\")";
                    else //query de cualquier otro tipo de dato
                        where += property.Name + " = " + value;
                }
            }
            var elementos = dbset.SqlQuery("select * from " + elemento_campos.GetType().Name + " where " + where);
            return elementos.ToList();
        }
    }
}