using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class CreateModel : PageModel
    { 

         private readonly IREscenario _repoEsc;

        [BindProperty]
        public Escenario Escenario { get; set; }

        //Metodos
        //Constructor
        public CreateModel(IREscenario repoEsc)
        {
            this._repoEsc= repoEsc;
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
            bool funciono= _repoEsc.CrearEscenario(Escenario);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "No puede crear Escenario con Nombre repetidos";
                return Page();
            }
        }
    }
}

