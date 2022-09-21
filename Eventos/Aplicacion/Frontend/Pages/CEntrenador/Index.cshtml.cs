using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class IndexModel : PageModel
    {
       //Atributos
        private readonly IREntrenador _repoEntrenador;
        private readonly IREquipo _repoEqui;

        [BindProperty]
        public IEnumerable<Entrenador> Entrenadores {get;set;}
        
        public List<EntrenadorView> EntrenadorView = new List<EntrenadorView>();
        

        //Metodos
        //Constructor
        public IndexModel(IREntrenador repoEntrenador, IREquipo repoEqui)
        {
            this._repoEntrenador= repoEntrenador;
            this._repoEqui= repoEqui;
        }

        //Enivar vistas y/o valores  al usuario 
        public void OnGet()
        {
            List<Equipo> lstEquipos= _repoEqui.ListarEquipos1();
            Entrenadores=_repoEntrenador.ListarEntrenadores();
            EntrenadorView ev=null;

            foreach (var e in Entrenadores)
            {
                ev=new EntrenadorView();
                foreach (var p in lstEquipos)
                {
                    if(e.EquipoId==p.Id)
                    {
                        ev.Equipo= p.Nombre;
                    }                   
                }
                ev.Id=e.Id;
                ev.Documento=e.Documento;
                ev.Nombres=e.Nombres;
                ev.Apellidos=e.Apellidos;
                ev.Celular=e.Celular;
                ev.Correo=e.Correo;
                ev.Modalidad= e.Modalidad;
                
                EntrenadorView.Add(ev);               
            }

        }
    }
}