using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio

{
    public class Arbitro
    {
        //Propiedades
        //[Key]
        public int Id {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string Documento{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string Nombre {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string Apellidos{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]


        public string Modalidad{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(6, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]


        public string Rh {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(8, ErrorMessage="el campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage=" el campo {0} de tener al menos {1} caracteres")]

        public string Celular {get;set;}

        //llava foranea para la relacion con Torneo
       // [Required(ErrorMessage="Este campo es obligatorio")]
       //  public int TorneoId { get; set; }

       public int ColegioId {get;set;}

      // public int TorneoId{get;set;}
          

 //Relacion con Equipo, propiedad navigacional

      // public List<Torneo> Torneos {get;set;}



      }
}