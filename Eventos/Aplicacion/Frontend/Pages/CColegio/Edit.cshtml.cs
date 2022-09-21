using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegio
{
    public class EditModel : PageModel
    {
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Colegio Colegio { get; set; }

        public EditModel(IRColegio repoCol)
        {
            this._repoCol =repoCol;
        }

        public ActionResult OnGet(int id)
        {
            Colegio= _repoCol.BuscarColegio(id);
            return Page();
        }

        public ActionResult OnPost()
        {  /*
            if(!ModelState.IsValid)
            {
                return Page();
            }*/
            bool funciono= _repoCol.ActualizarColegio(Colegio);
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
