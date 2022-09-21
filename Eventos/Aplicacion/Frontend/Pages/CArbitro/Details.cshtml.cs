using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class DetailsModel : PageModel
    {
       private readonly IRArbitro _repoArb;
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Arbitro Arbitro{get;set;}
        public Colegio Colegio{get;set;}

        public DetailsModel(IRColegio repoCol, IRArbitro repoArb)
        {
            this._repoCol= repoCol;
            this._repoArb= repoArb;
        }

        public ActionResult OnGet(int id)
        {
            Arbitro=_repoArb.BuscarArbitro(id);
            Colegio= _repoCol.BuscarColegio(Arbitro.ColegioId);

            if(Arbitro!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Arbitro no encontrado";
                return Page();
            }
        }
    }
}
