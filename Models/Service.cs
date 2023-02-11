using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IsiGestionElementaire.Models
{
    public class Service
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Libelle"), Required(ErrorMessage = "*"), MaxLength(20)]
        public string Libelle { get; set; }
        [Display(Name = "Montant"), Required(ErrorMessage = "*")]
        public Double Montant { get; set; }
        [Display(Name = "Type"), Required(ErrorMessage = "*"), MaxLength(20)]
        public string Type { get; set; }
    }
}