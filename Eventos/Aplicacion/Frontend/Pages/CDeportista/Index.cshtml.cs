using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class IndexModel : PageModel
    {
//Atributos
        private readonly IRDeportista _repoDep ;
        public IEnumerable<Deportista> Deportistas {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRDeportista _repoDep)
        {
            this._repoDep=_repoDep;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            Deportistas=_repoDep.ListarDeportistas();
        }
    }
}
