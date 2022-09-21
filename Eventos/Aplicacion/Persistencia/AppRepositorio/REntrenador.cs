using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class REntrenador:IREntrenador
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public REntrenador(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearEntrenador(Entrenador entrenador)
        {
            bool creado=false;
            //bool ex= Existe(entrenador);
           // if(!ex)
           // {
                try
                {
                    this._appContext.Entrenadores.Add(entrenador);
                    this._appContext.SaveChanges();
                    creado= true;
                }
                catch (System.Exception)
                {                
                    creado=false;
                }
          //  }     
            return creado;
        }

        public Entrenador BuscarEntrenador(int id)
        {
            return _appContext.Entrenadores.Find(id);            
        }        

        public bool ActualizarEntrenador(Entrenador entrenador)
        {
            bool actualizado=false;
            var ent= _appContext.Entrenadores.Find(entrenador.Id);
            if(ent != null)
            {                
                try
                {
                    ent.Nombres= entrenador.Nombres;
                    ent.Documento=entrenador.Documento;
                    ent.Apellidos=entrenador.Apellidos;
                    ent.Modalidad=entrenador.Modalidad;
                    ent.Correo = entrenador.Correo;
                    ent.Celular= entrenador.Celular;     
                    ent.EquipoId= entrenador.EquipoId;            
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

        public bool EliminarEntrenador(int id)
        {
            bool eliminado= false;
            var ent= this._appContext.Entrenadores.Find(id);
            if(ent != null)
            {
                try
                {
                    this._appContext.Entrenadores.Remove(ent);
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

        public List<Entrenador> ListarEntrenador1()
        {
            return this._appContext.Entrenadores.ToList(); //select * from Entrenadores
        }

        public IEnumerable<Entrenador> ListarEntrenadores()
        {
            return this._appContext.Entrenadores;
        }
/*
        private bool Existe(Entrenador entrenador)
        {
            bool ex= false;
            Entrenador ent= _appContext.Entrenadores.FirstOrDefault(d=> d.Documento == entrenador.Documento);
            if(ent != null)
            {
                ex=true;
            }
            return ex;
        }
*/
    }
}