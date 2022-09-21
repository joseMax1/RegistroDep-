using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRColegio
    {
        public bool CrearColegio(Colegio colegio);
        public Colegio BuscarColegio(int id);
        public bool ActualizarColegio(Colegio colegio);
        public bool EliminarColegio(int id);
        public IEnumerable<Colegio> ListarColegio();

     public List<Colegio> ListarColegios1();

        public Colegio BuscarColegioD(string nit);
    }
}

