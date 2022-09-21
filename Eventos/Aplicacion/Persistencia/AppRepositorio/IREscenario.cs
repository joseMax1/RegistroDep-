using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IREscenario
    {
        public bool CrearEscenario(Escenario escenario);
        public Escenario BuscarEscenario(int id);
        public bool ActualizarEscenario(Escenario escenario);
        public bool EliminarEscenario(int id);
        public IEnumerable<Escenario> ListarEscenarios();
        public List<Escenario> ListarEscenario1();
    }
}