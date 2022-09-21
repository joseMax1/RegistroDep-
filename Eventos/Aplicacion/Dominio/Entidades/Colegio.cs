using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Colegio
    {        
        //Propiedades
        public int Id {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(12, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(5, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Nit {get;set;}

       
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string RazonSocial {get;set;}

      
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Direccion {get;set;}

       
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(5, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Telefono {get;set;}

      
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Modalidad {get;set;}

   
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(25, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]    
        public string Licencia {get;set;}

        public List<Arbitro> Arbitros {get;set;}

        // relacion con arbitro

    }
}
