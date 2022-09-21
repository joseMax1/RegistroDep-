using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;


namespace Frontend.Pages.CTorneoEquipo
{
    public class DeleteModel : PageModel
    {
       private readonly IRTorneoEquipo _repoTorEqu;
        private readonly IREquipo _repoEquipo;
        private readonly IRTorneo _repoTor;

        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}
        public Torneo Torneo {get;set;}
        public Equipo Equipo {get;set;}

        public DeleteModel(IRTorneoEquipo repoTorEqu, IREquipo repoEquipo, IRTorneo repoTor)
        {
            this._repoTorEqu= repoTorEqu;
            this._repoEquipo= repoEquipo;
            this._repoTor= repoTor;
        }

        public ActionResult OnGet(int idT, int idE)
        {
            TorneoEquipo= _repoTorEqu.BuscarTorneoEquipo(idT,idE);
            Torneo= _repoTor.BuscarTorneo(idT);
            Equipo= _repoEquipo.BuscarEquipo(idE);

            if(TorneoEquipo != null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]= "Registro no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoTorEqu.EliminarTorneoEquipo(TorneoEquipo.TorneoId, TorneoEquipo.EquipoId);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El equipo no puede ser eliminado del torneo";
                return Page();
            }
        }
    }
}
