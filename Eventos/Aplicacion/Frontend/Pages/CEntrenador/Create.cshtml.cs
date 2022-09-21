using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class CreateModel : PageModel
    {
       private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEqui;

        [BindProperty]
        public Entrenador Entrenador {get;set;}   
        public IEnumerable<Equipo> Equipos {get;set;}

        //Constructor
        public CreateModel(IREntrenador repoEntrenador, IREquipo repoEqu)
        {
            this._repoEntrenador= repoEntrenador;
            this._repoEqui= repoEqu;
        }

        public ActionResult OnGet()
        {
            Equipos= _repoEqui.ListarEquipos();
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
            bool funciono= _repoEntrenador.CrearEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos= _repoEqui.ListarEquipos();
                ViewData["Error"]="No se pueden registrar Entrenador con el mismo nombre";
                return Page();
            }            
            
        }
    }
}
