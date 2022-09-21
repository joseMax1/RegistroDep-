using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class RUnidadDeportiva:IRUnidadDeportiva
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RUnidadDeportiva(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearUnidadDeportiva(UnidadDeportiva unidadDeportiva)
        {
            bool creado=false;
            try
            {
                this._appContext.UnidadDeportivas.Add(unidadDeportiva);
                this._appContext.SaveChanges();
                creado= true;
            }
            catch (System.Exception)
            {                
                creado=false;
            }               
            return creado;
        }

        public UnidadDeportiva  BuscarUnidadDeportiva(int id)
        {
            return _appContext.UnidadDeportivas.Find(id);            
        }        

        public bool ActualizarUnidadDeportiva(UnidadDeportiva unidadDeportiva)
        {
            bool actualizado=false;
            var uni= _appContext.UnidadDeportivas.Find(unidadDeportiva.Id);
            if(uni != null)
            {                
                try
                {
                    uni.Nombre= unidadDeportiva.Nombre;
                    uni.Direccion= unidadDeportiva.Direccion;
                    uni.EscenarioId= unidadDeportiva.EscenarioId;                  
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

        public bool EliminarUnidadDeportiva(int id)
        {
            bool eliminado= false;
            var uni= this._appContext.UnidadDeportivas.Find(id);
            if(uni != null)
            {
                try
                {
                    this._appContext.UnidadDeportivas.Remove(uni);
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

        public List<UnidadDeportiva> ListarUnidadDeportiva1()
        {
            return this._appContext.UnidadDeportivas.ToList(); //select * from Municipios
        }

        public IEnumerable<UnidadDeportiva>  ListarUnidadDeportivas()
        {
            return this._appContext.UnidadDeportivas;
        }
        
    }
}