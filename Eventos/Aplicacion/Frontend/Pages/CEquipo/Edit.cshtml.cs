using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class EditModel : PageModel
    {
         private readonly IREquipo _repoEqu;
        private readonly IRPatrocinador _repoPat;

        [BindProperty]
        public Equipo Equipo { get; set; }

        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        public EditModel(IREquipo repoEqu, IRPatrocinador repoPat)
        {
            this._repoEqu= repoEqu;
            this._repoPat= repoPat;
        }       

        public ActionResult OnGet(int id)
        {
            Equipo= _repoEqu.BuscarEquipo(id);
            if(Equipo!=null)
            {
                Patrocinadores= _repoPat.ListarPatrocinadores();
                return Page();
            }
            else
            {
                Patrocinadores= _repoPat.ListarPatrocinadores();
                ViewData["Error"]="Equipo no encontrado";
                return Page();
            }           
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Patrocinadores= _repoPat.ListarPatrocinadores();
                return Page();
            }
            //Municipios= _repoMun.ListarMunicipios();
            bool funciono= _repoEqu.ActualizarEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Patrocinadores= _repoPat.ListarPatrocinadores();
                ViewData["Error"]="Ya hay registrado un Equipo con el nombre: " + Equipo.Nombre;
                return Page();
            }
        }
    }
}