using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{public class CreateModel : PageModel
    {
        private readonly IRUnidadDeportiva _repoUnidadDeportiva;
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public UnidadDeportiva UnidadDeportiva {get;set;}   
        public IEnumerable<Escenario> Escenarios {get;set;}

        //Constructor
        public CreateModel(IRUnidadDeportiva repoUnidadDeportiva, IREscenario repoEsc)
        {
            this._repoUnidadDeportiva= repoUnidadDeportiva;
            this._repoEsc= repoEsc;
        }

        public ActionResult OnGet()
        {
            Escenarios= _repoEsc.ListarEscenarios();
            return Page();
        }

        public ActionResult OnPost()
        { /*
            if(!ModelState.IsValid)
            {
                Patrocinadores= _repoPat.ListarPatrocinadores();
                return Page();
            }
            */
            bool funciono= _repoUnidadDeportiva.CrearUnidadDeportiva(UnidadDeportiva);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Escenarios= _repoEsc.ListarEscenarios();
                ViewData["Error"]="No se pueden registrar Equipos con el mismo nombre";
                return Page();
            }            
            
        }
    }
}