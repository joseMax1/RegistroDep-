/*using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRTorneoEquipo
    {
        public bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        public TorneoEquipo BuscarTorneoEquipo(int idT,int idE);
       // public bool EliminarTorneoEquipo(int id);
        public IEnumerable<TorneoEquipo> ListarTorneoEquipo();
        
    }
}*/

using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public interface IRTorneoEquipo
    {
        public bool CrearTorneoEquipo(TorneoEquipo obj);
        public TorneoEquipo BuscarTorneoEquipo(int idT, int idE);
        public bool EliminarTorneoEquipo(int idT, int idE);
        public IEnumerable<TorneoEquipo> ListarTorneoEquipos();        
    }
}