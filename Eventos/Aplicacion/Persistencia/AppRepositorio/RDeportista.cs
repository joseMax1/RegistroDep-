using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class RDeportista:IRDeportista
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RDeportista(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearDeportista(Deportista deportista)
        {
            bool creado=false;
            bool ex= Existe(deportista);
            if(!ex)
            {
                try
                {
                    this._appContext.Deportistas.Add(deportista);
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

        public Deportista BuscarDeportista(int id)
        {
            return _appContext.Deportistas.Find(id);            
        }        

        public bool ActualizarDeportista(Deportista deportista)
        {
            bool actualizado=false;
            var dep= _appContext.Deportistas.Find(deportista.id);
            if(dep != null)
            {                
                try
                {
                    dep.Nombre= deportista.Nombre;
                    dep.Documento=deportista.Documento;
                    dep.Apellidos=deportista.Apellidos;         
                    dep.Genero=deportista.Genero;
                    dep.Modalidad=deportista.Modalidad;
                    dep.FechaNacimiento=deportista.FechaNacimiento;
                    dep.Rh=deportista.Rh;
                    dep.EPS=deportista.EPS;
                    dep.Celular=deportista.Celular;
                    dep.Correo=deportista.Correo;          
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

        public bool EliminarDeportista(int id)
        {
            bool eliminado= false;
            var dep= this._appContext.Deportistas.Find(id);
            if(dep != null)
            {
                try
                {
                    this._appContext.Deportistas.Remove(dep);
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

        public List<Deportista> ListarDeportista1()
        {
            return this._appContext.Deportistas.ToList(); //select * from Deportistas
        }

        public IEnumerable<Deportista> ListarDeportistas()
        {
            return this._appContext.Deportistas;
        }

        private bool Existe(Deportista deportista)
        {
            bool ex= false;
            Deportista dep= _appContext.Deportistas.FirstOrDefault(d=> d.Documento == deportista.Documento);
            if(dep != null)
            {
                ex=true;
            }
            return ex;
        }

    }
}