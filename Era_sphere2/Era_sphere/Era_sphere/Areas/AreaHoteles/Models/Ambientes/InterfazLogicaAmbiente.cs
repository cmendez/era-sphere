using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaHoteles.Models.Ambientes
{
    public interface InterfazLogicaAmbiente
    {
        void modificarAmbiente(AmbienteView piso);
        void agregarAmbiente(AmbienteView piso);
        void eliminarAmbiente(int ambiente_id);
        List<AmbienteView> retornarAmbientes();
        List<AmbienteView> retornarAmbientes(int idhotel);
        AmbienteView retornarAmbiente(int ambiente_id);
        List<Ambiente> buscarAmbiente(Ambiente ambiente);
    }
}