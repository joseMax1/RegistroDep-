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
    public class CrearUsuarioModel : PageModel
    {
        private readonly IRLogin _repoLogin;

        [BindProperty]
        public Login Login{get;set;}

        public CrearUsuarioModel(IRLogin repoLogin)
        {
            this._repoLogin= repoLogin;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            bool funciono= _repoLogin.CrearLogin(Login);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El usuario: " + Login.Usuario + " ya se encuentra registrado";
                return Page();
            }
        }
    }
}