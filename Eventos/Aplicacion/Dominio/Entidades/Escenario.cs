using System.Collections.Generic;
namespace Dominio
{
    public class Escenario
    {        
        //Propiedades
        public int Id {get;set;}
        public string Nombre {get;set;}
        public int Espectadores {get;set;}
        public string Tipo {get;set;}
        public int UnidadDeportivaId { get; set; }
        
       

        public List<UnidadDeportiva> UnidadDeportivas {get;set;}

    }
}