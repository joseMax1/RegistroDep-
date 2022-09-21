using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class DetailsModel : PageModel
    {
        private readonly IREntrenador _repoEnt;

        [BindProperty]
        public Entrenador Entrenador {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IREntrenador repoEnt)
        {
            this._repoEnt= repoEnt;
        }

        public ActionResult OnGet(int id)
        {
            Entrenador= _repoEnt.BuscarEntrenador(id);
            return Page();
        }
    }
}
