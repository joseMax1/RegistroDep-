using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia
{
    public class RColegio:IRColegio
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RColegio(AppContext appContext)
        {
            this._appContext=appContext;
        }

//****************** Crear Patrocinador ***************************************//
       public bool CrearColegio(Colegio colegio)
        {
            bool creado=false;
            bool ex= Existe(colegio);
            if(!ex)
            {
                try
                {
                    this._appContext.colegios.Add(colegio);
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

//****************** Buscar Colegio ***************************************//


        public Colegio BuscarColegio(int id)
        {
            Colegio colegio= _appContext.colegios.Find(id);
            return colegio;
        }
            public Colegio BuscarColegioD(string nit)
        {
            Colegio colegio= _appContext.colegios.FirstOrDefault(c=> c.Nit== nit);
            return colegio;
        }
//****************** Actualizar Colegio ***************************************//

      public bool ActualizarColegio(Colegio colegio)
        {
            bool actualizado=false;
            var col= _appContext.colegios.Find(colegio.Id);
            if(col != null)
            {
                bool ex= Existe(colegio);
                if(!ex)
                {
                    try
                    {
                        col.Nit= colegio.Nit;
                        col.RazonSocial=colegio.RazonSocial;
                        col.Direccion=colegio.Direccion;
                        col.Telefono= colegio.Telefono;
                        col.Modalidad= colegio.Modalidad;
                        col.Licencia=colegio.Licencia;
                        _appContext.SaveChanges();
                        actualizado=true;
                    }
                    catch(System.Exception)
                    {
                        actualizado=false;
                    }
                }                
            }
            return actualizado;
        }
//****************** Eliminar Patrocinador ***************************************//

        public bool EliminarColegio(int id)
        {
            bool eliminado= false;
            var col= this._appContext.colegios.Find(id);
            if(col != null)
            {
                try
                {
                    this._appContext.colegios.Remove(col);
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
//****************** Listar Patrocinador ***************************************//
   
   public List<Colegio> ListarColegios1()
      {
            return this._appContext.colegios.ToList();
      }
        public IEnumerable<Colegio> ListarColegio()
        {
            return this._appContext.colegios;
        }

       

//****************** Existe Patrocinador ***************************************//

        private bool Existe(Colegio colegio)
        {
            bool ex= false;
            Colegio col= _appContext.colegios.FirstOrDefault(c=> c.Nit == colegio.Nit);
            if(col != null)
            {
                ex=true;
            }
            return ex;
        }

    }
}