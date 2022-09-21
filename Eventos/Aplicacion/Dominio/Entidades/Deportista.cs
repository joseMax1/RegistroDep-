using System.ComponentModel;
namespace Dominio

{
    public class Deportista
    {
         public int     id    {get;set;}
        public string Nombre {get;set;}

        public string Documento {get;set;}
        public string Apellidos {get;set;}
        public string Genero{get;set;}

        public string Modalidad {get;set;}

         public DateTime FechaNacimiento {get;set;}        

        public string  Rh {get;set;} 

        public string EPS {get;set;}      

        public string Celular {get;set;}  

        public string Correo {get;set;}              

        public List<Equipo> Equipos {get;set;}

    

    }
}