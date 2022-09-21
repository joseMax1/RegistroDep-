using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class DeleteModel : PageModel
    {
     

  private readonly IRDeportista _repoDep;

        [BindProperty]
        public Deportista Deportista{ get; set; }

        //Metodos
        //Constructor

        public DeleteModel(IRDeportista repoDep)
        {
            this._repoDep=repoDep;
        }

        //enviar informacion al formulario
        public ActionResult OnGet(int id)
        {
            Deportista= _repoDep.BuscarDeportista(id);
            if(Deportista== null)
            {
                ViewData["Error"]="Deportista no encontrado";
                return Page();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoDep.EliminarDeportista(Deportista.id);
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

