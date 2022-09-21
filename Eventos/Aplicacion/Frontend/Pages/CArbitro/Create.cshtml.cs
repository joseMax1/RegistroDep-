using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
namespace Frontend.Pages.CArbitro
{
    public class CreateModel : PageModel
    {
     private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Arbitro Arbitro {get;set;}   
        public IEnumerable<Colegio> Colegios{get;set;}

        //Constructor
        public CreateModel(IRArbitro repoArbitro, IRColegio repoCol)
        {
            this._repoArbitro= repoArbitro;
            this._repoCol= repoCol;
        }

        public ActionResult OnGet()
        {
            Colegios= _repoCol.ListarColegio();
            return Page();
        }

        public ActionResult OnPost()
        { /*
            if(!ModelState.IsValid)
            {
                Colegios= _repoCol.ListarColegio();
                return Page();
            }*/
            
            bool funciono= _repoArbitro.CrearArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Colegios= _repoCol.ListarColegio();
                ViewData["Error"]="No se pueden registrar Arbitro con el mismo documento";
                return Page();
            }            
            
        }
    }
}