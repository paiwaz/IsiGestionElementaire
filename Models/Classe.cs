using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IsiGestionElementaire.Models
{
    public class Classe
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Libelle"), Required(ErrorMessage = "*"), MaxLength(8)]
        public string Libelle { get; set; }
        [Display(Name = "Niveau"), Required(ErrorMessage = "*"), MaxLength(5)]
        public string Niveau { get; set; }
    }
}