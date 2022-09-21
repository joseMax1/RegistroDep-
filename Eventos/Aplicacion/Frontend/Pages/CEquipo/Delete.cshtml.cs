using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class DeleteModel : PageModel
    {
        private readonly IREquipo _repoEqu;
        private readonly IRPatrocinador _repoPat;

        [BindProperty]
        public Equipo Equipo{ get; set; }
        public Patrocinador Patrocinador {get;set;}

        public DeleteModel(IREquipo repoEqu, IRPatrocinador repoPat)
        {
            this._repoEqu= repoEqu;
            this._repoPat= repoPat;
        }
        public ActionResult OnGet(int id)
        {
            Equipo=_repoEqu.BuscarEquipo(id);
            Patrocinador= _repoPat.BuscarPatrocinador(Equipo.PatrocinadorId);

            if(Equipo!= null)
            {
                return Page();
            }
            else
            {
                ViewData["Error"]="Equipo no encontrado";
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool eliminado= _repoEqu.EliminarEquipo(Equipo.Id);
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