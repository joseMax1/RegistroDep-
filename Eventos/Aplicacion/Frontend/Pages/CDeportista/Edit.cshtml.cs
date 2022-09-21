using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class EditModel : PageModel
    {
private readonly IRDeportista _repoDep;

        [BindProperty]
        public Deportista Deportista { get; set; }

        public EditModel(IRDeportista repoDep)
        {
            this._repoDep =repoDep;
        }

        public ActionResult OnGet(int id)
        {
            Deportista= _repoDep.BuscarDeportista(id);
            return Page();
        }

        public ActionResult OnPost()
        {  /*
            if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoDep.ActualizarDeportista(Deportista);
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
