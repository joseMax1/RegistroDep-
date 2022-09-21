using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class  RArbitro:IRArbitro
    {
        //atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor por defecto
        public RArbitro(AppContext appContext)
        {
            this._appContext=appContext;
        }

        public bool CrearArbitro(Arbitro arbitro)
        {
            bool creado=false;
           // bool ex= Existe(arbitro);
           // if(!ex)
           // {
                try
                {
                    this._appContext.Arbitros.Add(arbitro);
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

        public Arbitro BuscarArbitro(int id)
        {

            return _appContext.Arbitros.Find(id);            
        }

        

        public bool ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado=false;
            var arb= _appContext.Arbitros.Find(arbitro.Id);
            if(arb != null)
            {
                //bool ex= Existe(arbitro);
                //if(!ex)
                {
                    try
                    {
                        arb.Documento= arbitro.Documento;
                        arb.Nombre= arbitro.Nombre;
                        arb.Apellidos=arbitro.Apellidos;
                        arb.Modalidad= arbitro.Modalidad;
                        arb.Rh= arbitro.Rh;
                        arb.Celular=arbitro.Celular;
                        arb.ColegioId=arbitro.ColegioId;
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

        public bool EliminarArbitro(int idArbitro)
        {
            bool eliminado= false;
            var arb= this._appContext.Arbitros.Find(idArbitro);
            if(arb != null)
            {
                try
                {
                    this._appContext.Arbitros.Remove(arb);
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

        public List<Arbitro> ListarArbitros1()
        {
            return this._appContext.Arbitros.ToList(); //select * from Municipios
        }
        
        public IEnumerable<Arbitro> ListarArbitros()
        {
            return this._appContext.Arbitros;
        }

        /*private bool Existe(Arbitro arbitro)
        {
            bool ex= false;
            Arbitro arb= _appContext.Arbitros.FirstOrDefault(a=> a.Nombre == arbitro.Nombre);
            if(arb != null)
            {
                ex=true;
            }
            return ex;
        }
        */

    }
}