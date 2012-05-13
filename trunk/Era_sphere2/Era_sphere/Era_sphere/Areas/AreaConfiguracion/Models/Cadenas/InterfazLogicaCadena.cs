using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Cadenas
{
    public interface InterfazLogicaCadena
    {
        List<Cadena> retornarClientes();
        Cadena retornarCadena(int cadena_id);
        void modificarCadena(Cadena cadena);
        void agregarCadena(Cadena cadena);
        void eliminarCadena(int cadena_id);
        List<Cadena> buscarCadena(Cadena cadena);

    }
}