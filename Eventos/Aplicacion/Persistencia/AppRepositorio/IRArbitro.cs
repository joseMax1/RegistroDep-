using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRArbitro
    {
        public bool CrearArbitro(Arbitro arbitro);
        public Arbitro BuscarArbitro(int id);
        public bool ActualizarArbitro(Arbitro arbitro);
        public bool EliminarArbitro(int id);
        public List<Arbitro>ListarArbitros1();
        public IEnumerable<Arbitro> ListarArbitros();
        
    }
}