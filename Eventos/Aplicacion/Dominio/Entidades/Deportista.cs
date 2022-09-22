using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Dominio

{
    public class Deportista
    {
         public int     id    {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        [Display(Name="Nombre Deportista")]
        public string Nombre {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(12, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        
        public string Documento {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
       
        public string Apellidos {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(12, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Genero{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        
        public string Modalidad {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [DataType(DataType.Date)]
         public DateTime FechaNacimiento {get;set;}    

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(15, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string  Rh {get;set;} 
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(15, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string EPS {get;set;}      
       [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(15, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string Celular {get;set;}  
         [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(15, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Correo {get;set;}      

        [Required(ErrorMessage="Este campo es obligatorio")]
        

        public List<Equipo> Equipos {get;set;}

    

    }
}