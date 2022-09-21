using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class EditModel : PageModel
    {
       
        private readonly IRArbitro _repoArb;
        private readonly IRColegio _repoCol;

        [BindProperty]
        public Arbitro Arbitro{ get; set; }

        public IEnumerable<Colegio> Colegios {get;set;}

        public EditModel(IRArbitro repoArb, IRColegio repoCol)
        {
            this._repoCol= repoCol;
            this._repoArb= repoArb;
        }       

        public ActionResult OnGet(int id)
        {
            Arbitro= _repoArb.BuscarArbitro(id);
            if(Arbitro!=null)
            {
                Colegios= _repoCol.ListarColegio();
                return Page();
            }
            else
            {
                Colegios= _repoCol.ListarColegio();
                ViewData["Error"]="Colegio no encontrado";
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
            bool funciono= _repoArb.ActualizarArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Colegios= _repoCol.ListarColegio();
                ViewData["Error"]="Ya hay registrado un Arbitro con el nombre: " + Arbitro.Nombre;
                return Page();
            }
        }
    }
}