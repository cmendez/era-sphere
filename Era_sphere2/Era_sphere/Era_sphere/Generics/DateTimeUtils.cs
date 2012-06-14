using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Generics
{
    public class DateTimeUtils
    {
        //devuelve si existe interseccion entre las fechas
        public static bool tieneInterseccion(DateTime fechaInicio1,DateTime fechaFin1,DateTime fechaInicio2,DateTime fechaFin2){
            return (estaAdentro(fechaInicio1, fechaFin1, fechaInicio2) || estaAdentro(fechaInicio1, fechaFin1, fechaFin2) ||
                    estaAdentro(fechaInicio2, fechaFin2, fechaInicio1) );
        }
        //verifica si "fecha" entra del de fechaInicio y fechaFin
        public static bool estaAdentro(DateTime fechaInicio , DateTime fechaFin, DateTime fecha){
            return (fechaInicio<=fecha && fecha<=fechaFin);
        }
    }
}