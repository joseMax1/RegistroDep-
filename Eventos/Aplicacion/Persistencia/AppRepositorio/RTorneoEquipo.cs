/*using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class  RTorneoEquipo:IRTorneoEquipo
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RTorneoEquipo(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool creado=false;
           // bool ex= Existe(arbitro);
           // if(!ex)
           // {
                try
                {
                    this._appContext.TorneoEquipos.Add(torneoEquipo);
                    this._appContext.SaveChanges();
                    creado= true;
                }
                catch (System.Exception)
                {                
                    creado=false;
                }
            //}     
            return creado;
        }

       public TorneoEquipo BuscarTorneoEquipo(int idT ,int idE)
        {

            return _appContext.TorneoEquipos.FirstOrDefault(t=>t.TorneoId==idT &&  t.EquipoId==idE);            
        }

        

       /*
         public bool EliminarTorneoEquipo(int idT ,int idE)
        {
            bool eliminado= false;
            var tor= this._appContext.TorneoEquipos.FirstOrDefault(t=>t.idTorneoId== idT && t.EquipoId==idE);
            if(tor != null)
            {
                try
                {
                    this._appContext.TorneoEquipos.Remove(tor);
                    this._appContext.SaveChanges();
                    eliminado= true;
                }
                catch (System.Exception)
                {                    
                   eliminado=false;
                }
            }
        }
        public IEnumerable<TorneoEquipo> ListarTorneoEquipo()
        {
            return this._appContext.TorneoEquipos;
        }

        private bool Existe(TorneoEquipo obj)
        {
            bool ex= false;
            vat tor= _appContext.TorneoEquipos.FirstOrDefault(t=> t.EquipoId == obj.EquipoId
                                                            && t.TorneoId== obj.TorneoId);
            if(tor != null)
            {
                ex=true;
            }
            return ex;
        }
        */
using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class RTorneoEquipo:IRTorneoEquipo
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RTorneoEquipo(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearTorneoEquipo(TorneoEquipo obj)
        {
            bool creado=false;
            bool ex= Existe(obj);
            if(!ex)
            {
                try
                {
                    this._appContext.TorneoEquipos.Add(obj);
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

        public TorneoEquipo BuscarTorneoEquipo(int idT, int idE)
        {
            return _appContext.TorneoEquipos.FirstOrDefault(t => t.TorneoId==idT 
                                                            && t.EquipoId==idE);            
        }        

        public bool EliminarTorneoEquipo(int idT, int idE)
        {
            bool eliminado= false;
            var tor= this._appContext.TorneoEquipos.FirstOrDefault(t=> t.TorneoId== idT
                                                                        && t.EquipoId== idE);
            if(tor != null)
            {
                try
                {
                    this._appContext.TorneoEquipos.Remove(tor);
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
        

        public IEnumerable<TorneoEquipo> ListarTorneoEquipos()
        {
            return this._appContext.TorneoEquipos;
        }

        private bool Existe(TorneoEquipo obj)
        {
            bool ex= false;
            var tor= _appContext.TorneoEquipos.FirstOrDefault(t=> t.EquipoId == obj.EquipoId
                                                                && t.TorneoId== obj.TorneoId);
            if(tor != null)
            {
                ex=true;
            }
            return ex;
        }
    }
}
