using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Collections;

namespace Era_sphere.Generics
{
    public class GenericBag
    {
        public static OrderedDictionary createBag(){
            return new OrderedDictionary();
        }

        public static OrderedDictionary deserializeBag(string cad)
        {
            OrderedDictionary dic = new OrderedDictionary();
            char [] sep={':',','};
            string[] arr = cad.Split(sep);
            for (int i=0;i<arr.Length;i++)
                dic.Add(arr[i], arr[i + 1]);
            return dic;
        }

        public static string serializeBag(OrderedDictionary dic)
        {
            IDictionaryEnumerator enumerator = dic.GetEnumerator();
            string aux = "";
            bool f = true;
            while (enumerator.MoveNext())
            {
                if (f) f = false;
                else aux += ",";
                string gg = enumerator.Key + ":" + enumerator.Value;
                aux += gg;
            }
            return aux;
        }
    }
}