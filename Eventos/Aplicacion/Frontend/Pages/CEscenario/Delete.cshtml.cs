using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
namespace Frontend.Pages.CEscenario
{
    public class DeleteModel : PageModel
    {
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public Escenario Escenario{ get; set; }

        //Metodos
        //Constructor

        public DeleteModel(IREscenario repoEsc)
        {
            this._repoEsc=repoEsc;
        }

        //enviar informacion al formulario
        public ActionResult OnGet(int id)
        {
            Escenario= _repoEsc.BuscarEscenario(id);
            if(Escenario== null)
            {
                ViewData["Error"]="Escenario no encontrado";
                return Page();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoEsc.EliminarEscenario(Escenario.Id);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No es posible eliminar este registro";
                return Page();
            }
        }
    }
}

