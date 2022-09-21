using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio
{
    public class UnidadDeportivaView
    {
        //Propiedades

        public int Id {get;set;}       
        public string Nombre {get;set;}        
        public string Direccion {get;set;}        
        
        //Relacion con Torneo     
        public string Escenario {get;set;}
       

        


    }
}