using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CUnidadDeportiva
{
   public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRUnidadDeportiva _repoUnidadDeportiva;
        private readonly IREscenario _repoEsc;

        [BindProperty]
        public IEnumerable<UnidadDeportiva> UnidadDeportivas {get;set;}
        
        public List<UnidadDeportivaView> UnidadDeportivaView = new List<UnidadDeportivaView>();
        

        //Metodos
        //Constructor
        public IndexModel(IRUnidadDeportiva repoUnidadDeportiva, IREscenario repoEsc)
        {
            this._repoUnidadDeportiva= repoUnidadDeportiva;
            this._repoEsc= repoEsc;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            List<Escenario> lstEscenarios= _repoEsc.ListarEscenario1();
            UnidadDeportivas=_repoUnidadDeportiva.ListarUnidadDeportivas();
            UnidadDeportivaView ev=null;

            foreach (var e in UnidadDeportivas)
            {
                ev=new UnidadDeportivaView();
                foreach (var p in lstEscenarios)
                {
                    if(e.EscenarioId==p.Id)
                    {
                        ev.Escenario= p.Nombre;
                    }                   
                }
                ev.Id=e.Id;
                ev.Nombre=e.Nombre;
                ev.Direccion= e.Direccion;
                
                UnidadDeportivaView.Add(ev);               
            }

        }
    }
}