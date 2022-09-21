using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class DeleteModel : PageModel
    {
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Colegio Colegio{ get; set; }

        //Metodos
        //Constructor

        public DeleteModel(IRColegio repoCol)
        {
            this._repoCol=repoCol;
        }

        //enviar informacion al formulario
        public ActionResult OnGet(int id)
        {
            Colegio= _repoCol.BuscarColegio(id);
            if(Colegio== null)
            {
                ViewData["Error"]="Colegio no encontrado";
                return Page();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoCol.EliminarColegio(Colegio.Id);
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
