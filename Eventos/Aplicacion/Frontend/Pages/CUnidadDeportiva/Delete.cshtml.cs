using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class DeleteModel : PageModel
    {
         private readonly IRUnidadDeportiva _repoUni;
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public UnidadDeportiva UnidadDeportiva{ get; set; }
        public Escenario  Escenario {get;set;}

        public DeleteModel(IRUnidadDeportiva repoUni, IREscenario repoEsc)
        {
            this._repoUni= repoUni;
            this._repoEsc= repoEsc;
        }
        public ActionResult OnGet(int id)
        {
            UnidadDeportiva=_repoUni.BuscarUnidadDeportiva(id);
            Escenario= _repoEsc.BuscarEscenario(UnidadDeportiva.EscenarioId);

            if(UnidadDeportiva!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="UnidadDeportiva no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoUni.EliminarUnidadDeportiva(UnidadDeportiva.Id);
            if(eliminado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El registro no se pudo eliminar";
                return Page();
            }
        }
    }
}
