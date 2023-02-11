using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsiGestionElementaire.Models
{
    public class ParentEleve
    {
        [Key]
        [Column(Order =1)]
        public int? IdEleve { get; set; }
        [ForeignKey("IdEleve")]
        public virtual Eleve eleve {get; set;}
        [Key]
        [Column(Order = 2)]
        public int? IdTuteur { get; set; }
        [ForeignKey("IdTuteur")]
        public virtual Tuteur tuteur { get; set; }

        [Display(Name = "Priorité"),
            Required(ErrorMessage = "*"), MaxLength(5)]
        public string Priorite { get; set; }

    }
}