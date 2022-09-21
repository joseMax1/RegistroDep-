using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;


namespace Frontend.Pages.CEscenario
{
    public class EditModel : PageModel
    {
       private readonly IREscenario _repoEsc;

        [BindProperty]
        public Escenario Escenario { get; set; }

        public EditModel(IREscenario repoEsc)
        {
            this._repoEsc =repoEsc;
        }

        public ActionResult OnGet(int id)
        {
            Escenario= _repoEsc.BuscarEscenario(id);
            return Page();
        }

        public ActionResult OnPost()
        {  /*
            if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoEsc.ActualizarEscenario(Escenario);
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