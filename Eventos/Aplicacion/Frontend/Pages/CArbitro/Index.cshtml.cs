using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class IndexModel : PageModel
    {
        private readonly IRArbitro _repoArbitro;
        private readonly IRColegio _repoCol;

        [BindProperty]
        public IEnumerable<Arbitro> Arbitros {get;set;}
        
        public List<ArbitroView> ArbitrosView = new List<ArbitroView>();
        

        //Metodos
        //Constructor
        public IndexModel(IRArbitro repoArbitro, IRColegio repoCol)
        {
            this._repoArbitro= repoArbitro;
            this._repoCol= repoCol;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            List<Colegio> lstColegios= _repoCol.ListarColegios1();
            Arbitros=_repoArbitro.ListarArbitros();
            ArbitroView ev=null;

            foreach (var e in Arbitros)
            {
                ev=new ArbitroView();
                foreach (var p in lstColegios)
                {
                    if(e.ColegioId==p.Id)
                    {
                        ev.Colegio= p.Nit;
                    }                   
                }
                ev.Id=e.Id;
                ev.Nombre=e.Nombre;
                ev.Documento= e.Documento;
                ev.Apellidos= e.Apellidos;
                ev.Modalidad= e.Modalidad;
                ev.Rh=e.Rh;
                ev.Celular=e.Celular;
                
                ArbitrosView.Add(ev);               
            }

        }
    }
}
