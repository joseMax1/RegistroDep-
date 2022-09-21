using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class RLogin:IRLogin
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RLogin(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearLogin(Login login)
        {
            bool creado=false;
            try
            {
                this._appContext.Logins.Add(login);
                this._appContext.SaveChanges();
                creado= true;
            }
            catch (System.Exception)
            {                
                creado=false;
            }               
            return creado;
        }

        public bool Validar(Login login)
        {
            bool valido= false;
            var user=_appContext.Logins.FirstOrDefault(l=> l.Usuario== login.Usuario
                                                        && l.Password== login.Password);
            
            if(user != null)
            {
                valido=true;
            }
            return valido;
        }

       
        
    }
}