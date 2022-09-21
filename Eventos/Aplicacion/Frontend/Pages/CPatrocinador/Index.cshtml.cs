using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador _repoPat;
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        //Metodos
        //Constructor
        public IndexModel(IRPatrocinador repoPat)
        {
            this._repoPat=repoPat;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            Patrocinadores=_repoPat.ListarPatrocinadores();
        }
    }
}

