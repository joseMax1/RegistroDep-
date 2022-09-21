using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class IniciarModel : PageModel
    {
        private readonly IRLogin _repoLogin;

        [BindProperty]
        public Login Login {get;set;}

        public IniciarModel(IRLogin repoLogin)
        {
            this._repoLogin= repoLogin;
        }
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repoLogin.Validar(Login);
            if(funciono)
            {
                return RedirectToPage("/CMunicipio/Index");
            }
            else
            {
                ViewData["Error"]="Erro de validación, verifique usuario y/o password";
                return Page();
            }
        }
    }
}
