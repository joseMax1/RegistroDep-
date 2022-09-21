using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRColegio _repoCol;
        public IEnumerable<Colegio> Colegios {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRColegio _repoCol)
        {
            this._repoCol=_repoCol;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            Colegios=_repoCol.ListarColegio();
        }
    }
}