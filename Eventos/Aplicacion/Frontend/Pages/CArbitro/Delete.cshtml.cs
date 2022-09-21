using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class DeleteModel : PageModel
    {
         private readonly IRArbitro _repoArb;
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Arbitro Arbitro { get; set; }
        public Colegio Colegio {get;set;}

        public DeleteModel(IRArbitro repoArb, IRColegio repoCol)
        {
            this._repoArb= repoArb;
            this._repoCol= repoCol;
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

        public ActionResult OnPost()
        {
            bool eliminado= _repoArb.EliminarArbitro(Arbitro.Id);
            if(eliminado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El registro no se pudo eliminar";
                return Page();
            }
        }
    }
}
