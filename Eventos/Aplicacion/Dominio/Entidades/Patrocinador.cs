/*using System.Collections.Generic;
using System.ComponentModel;
namespace Dominio

{
    public class Patrocinador
    {
         public int     id    {get;set;}
        public string Nombre {get;set;}

        public string Documento {get;set;}

        public string Tipo{get;set;}

        public string Direccion{get;set;}

        public string  Telefono{get;set;} 

        public List<Torneo> Torneos {get;set;}
        public List <Equipo> Equipos {get;set;}

    

    }
}
*/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Patrocinador
    {
        //Propiedades
        public int Id {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Nombres {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Documento {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(8, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(5, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Tipo {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(5, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Direccion {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(8, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]
        public string Telefono {get;set;}

        //Relacion con Equipo, propiedad navigacional
        public List<Equipo> Equipos {get;set;}

    }
}