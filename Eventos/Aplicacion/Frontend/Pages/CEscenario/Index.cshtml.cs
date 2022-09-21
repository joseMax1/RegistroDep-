using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IREscenario _repoEsc;
        public IEnumerable<Escenario> Escenarios {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IREscenario repoEsc)
        {
            this._repoEsc=repoEsc;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            Escenarios=_repoEsc.ListarEscenarios();
        }
    }
}