using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
    public class EditModel : PageModel
    {
        private readonly IRUnidadDeportiva _repoUni;
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public UnidadDeportiva UnidadDeportiva { get; set; }

        public IEnumerable<Escenario> Escenarios {get;set;}

        public EditModel(IRUnidadDeportiva repoUni, IREscenario repoEsc)
        {
            this._repoEsc= repoEsc;
            this._repoUni= repoUni;
        }       

        public ActionResult OnGet(int id)
        {
            UnidadDeportiva= _repoUni.BuscarUnidadDeportiva(id);
            if(UnidadDeportiva!=null)
            {
                Escenarios= _repoEsc.ListarEscenarios();
                return Page();
            }
            else
            {
                Escenarios= _repoEsc.ListarEscenarios();
                ViewData["Error"]="Escenario no encontrado";
                return Page();
            }           
        }

        public ActionResult OnPost()
        { /*
            if(!ModelState.IsValid)
            {
                Municipios= _repoMun.ListarMunicipios();
                return Page();
            }*/
            //Municipios= _repoMun.ListarMunicipios();
            bool funciono= _repoUni.ActualizarUnidadDeportiva(UnidadDeportiva);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Escenarios= _repoEsc.ListarEscenarios();
                ViewData["Error"]="Ya hay registrado un Escenario con el nombre: " + UnidadDeportiva.Nombre;
                return Page();
            }
        }
    }
}