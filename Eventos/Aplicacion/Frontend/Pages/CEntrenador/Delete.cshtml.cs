using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class DeleteModel : PageModel
    {
       private readonly IREntrenador _repoEnt;

        [BindProperty]
        public Entrenador Entrenador{ get; set; }

        //Metodos
        //Constructor

        public DeleteModel(IREntrenador repoEnt)
        {
            this._repoEnt=repoEnt;
        }

        //enviar informacion al formulario
        public ActionResult OnGet(int id)
        {
            Entrenador= _repoEnt.BuscarEntrenador(id);
            if(Entrenador== null)
            {
                ViewData["Error"]="Entrenador no encontrado";
                return Page();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoEnt.EliminarEntrenador(Entrenador.Id);
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


