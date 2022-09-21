using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class EditModel : PageModel
    {
            private readonly IREntrenador _repoEnt;

        [BindProperty]
        public Entrenador Entrenador { get; set; }

        public EditModel(IREntrenador repoEnt)
        {
            this._repoEnt =repoEnt;
        }

        public ActionResult OnGet(int id)
        {
            Entrenador= _repoEnt.BuscarEntrenador(id);
            return Page();
        }

        public ActionResult OnPost()
        {  /*
            if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoEnt.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No fue posible actualizar el registro";
                return Page();
            }
        }
    }
}