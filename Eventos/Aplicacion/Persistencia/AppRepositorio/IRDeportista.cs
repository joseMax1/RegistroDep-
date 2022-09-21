using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRDeportista
    {
        public bool CrearDeportista(Deportista deportista);
        public Deportista BuscarDeportista(int id);
        public bool ActualizarDeportista(Deportista deportista);
        public bool EliminarDeportista(int id);
        public IEnumerable<Deportista> ListarDeportistas();
        public List<Deportista> ListarDeportista1();
    }
}