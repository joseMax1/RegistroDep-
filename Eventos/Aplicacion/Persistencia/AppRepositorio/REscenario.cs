using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class REscenario:IREscenario
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public REscenario(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearEscenario(Escenario escenario)
        {
            bool creado=false;
            bool ex= Existe(escenario);
            if(!ex)
            {
                try
                {
                    this._appContext.Escenarios.Add(escenario);
                    this._appContext.SaveChanges();
                    creado= true;
                }
                catch (System.Exception)
                {                
                    creado=false;
                }
            }     
            return creado;
        }

        public Escenario BuscarEscenario(int id)
        {
            return _appContext.Escenarios.Find(id);            
        }        

        public bool ActualizarEscenario(Escenario escenario)
        {
            bool actualizado=false;
            var esc= _appContext.Escenarios.Find(escenario.Id);
            if(esc != null)
            {                
                try
                {
                    esc.Nombre= escenario.Nombre;
                    esc.Espectadores=escenario.Espectadores;
                    esc.Tipo= escenario.Tipo;
                    _appContext.SaveChanges();
                    actualizado=true;
                }
                catch(System.Exception)
                {
                    actualizado=false;
                }                              
            }
            return actualizado;
        }

        public bool EliminarEscenario(int id)
        {
            bool eliminado= false;
            var esc= this._appContext.Escenarios.Find(id);
            if(esc != null)
            {
                try
                {
                    this._appContext.Escenarios.Remove(esc);
                    this._appContext.SaveChanges();
                    eliminado= true;
                }
                catch (System.Exception)
                {                    
                   eliminado=false;
                }
            }
            return eliminado;
        }

        public List<Escenario> ListarEscenario1()
        {
            return this._appContext.Escenarios.ToList(); //select * from Municipios
        }

        public IEnumerable<Escenario> ListarEscenarios()
        {
            return this._appContext.Escenarios;
        }

        private bool Existe(Escenario escenario)
        {
            bool ex= false;
            Escenario esc= _appContext.Escenarios.FirstOrDefault(e=> e.Nombre == escenario.Nombre);
            if(esc != null)
            {
                ex=true;
            }
            return ex;
        }

    }
}