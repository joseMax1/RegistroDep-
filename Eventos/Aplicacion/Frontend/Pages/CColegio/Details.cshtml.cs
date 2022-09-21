using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class DetailsModel : PageModel
    {
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Colegio Colegio{get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRColegio repoCol)
        {
            this._repoCol= repoCol;
        }

        public ActionResult OnGet(int id)
        {
            Colegio= _repoCol.BuscarColegio(id);
            return Page();
        }
    }
}