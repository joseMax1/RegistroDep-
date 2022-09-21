using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class CreateModel : PageModel
    {
         private readonly IRDeportista _repoDep;

        [BindProperty]
        public Deportista Deportista { get; set; }

        //Metodos
        //Constructor
        public CreateModel(IRDeportista repoDep)
        {
            this._repoDep= repoDep;
        }

        //enviar informacion o vista al usuario
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {/*
            if(!ModelState.IsValid)
            {
                return Page();
            }
            */
            bool funciono= _repoDep.CrearDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "No se puede crear Deportista con documento repetidos";
                return Page();
            }
        }
    }
}
