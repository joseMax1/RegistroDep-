using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRUnidadDeportiva
    {
        public bool CrearUnidadDeportiva(UnidadDeportiva unidadDeportiva);
        public UnidadDeportiva BuscarUnidadDeportiva(int id);
        public bool ActualizarUnidadDeportiva(UnidadDeportiva unidadDeportiva);
        public bool EliminarUnidadDeportiva(int id);
        public IEnumerable<UnidadDeportiva> ListarUnidadDeportivas();
       // public UnidadDeportiva BuscarUnidadDeportivaN(string nom);

      public List<UnidadDeportiva> ListarUnidadDeportiva1();

    }
}