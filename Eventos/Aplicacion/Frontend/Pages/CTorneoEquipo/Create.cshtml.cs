using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneoEquipo
{
    public class CreateModel : PageModel
    {
       private  readonly IRTorneoEquipo _repoToQ;
        private readonly IREquipo _repoEqu;

        private readonly IRTorneo _repoTor;

        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}       
        public IEnumerable<Torneo> Torneos {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}

        //Constructor
        public CreateModel(IRTorneoEquipo repoToQ, IRTorneo repoTor, IREquipo repoEqu)
        {
            this._repoEqu=repoEqu;
            this._repoTor= repoTor;
            this._repoToQ=repoToQ;
        }

        public ActionResult OnGet()
        {
            Equipos= _repoEqu.ListarEquipos();
            Torneos= _repoTor.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
           // if(!ModelState.IsValid)
           // {
           //     return Page();
          //  }
            
            bool funciono= _repoToQ.CrearTorneoEquipo(TorneoEquipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos=_repoTor.ListarTorneos();
                Equipos=_repoEqu.ListarEquipos();
                ViewData["Error"]="No se pueden registrar torneoEquipo con el mismo nombre";
                return Page();
            }      
            
            
        }
    }
}
