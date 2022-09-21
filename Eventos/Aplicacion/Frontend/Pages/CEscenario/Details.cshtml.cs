using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class DetailsModel : PageModel
    {
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public Escenario Escenario {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IREscenario repoEsc)
        {
            this._repoEsc= repoEsc;
        }

        public ActionResult OnGet(int id)
        {
            Escenario= _repoEsc.BuscarEscenario(id);
            return Page();
        }
    }
}
