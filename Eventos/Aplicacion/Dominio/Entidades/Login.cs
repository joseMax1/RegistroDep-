using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio
{
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Login
    {
        //Propiedades
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        public string Usuario {get;set;}
        [MaxLength(12, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(8, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [DataType(DataType.Password)]
        public string Password {get;set;}      


    }
}