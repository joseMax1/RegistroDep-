using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class DetailsModel : PageModel
    {
    private readonly IRDeportista _repoDep;

        [BindProperty]
        public Deportista Deportista{get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRDeportista repoDep)
        {
            this._repoDep= repoDep;
        }

        public ActionResult OnGet(int id)
        {
            Deportista= _repoDep.BuscarDeportista(id);
            return Page();
        }
    }
}
