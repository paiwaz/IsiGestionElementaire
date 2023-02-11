using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IsiGestionElementaire.Models
{
    public class Exercice
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set;}
        [Display(Name ="Exercice"),Required(ErrorMessage ="*"),MaxLength(4)]
        public string Annee { get; set; }

    }
}