using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class CreateModel : PageModel
    { // Atributos
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Colegio Colegio { get; set; }

        //Metodos
        //Constructor
        public CreateModel(IRColegio repoCol)
        {
            this._repoCol= repoCol;
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
            bool funciono= _repoCol.CrearColegio(Colegio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]= "No puede crear Patrocinadore con documento repetidos";
                return Page();
            }
        }
    }
}

