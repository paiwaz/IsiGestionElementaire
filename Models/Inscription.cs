using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsiGestionElementaire.Models
{
    public class Inscription
    {
        [Key, Column(Order =1)]
        [ScaffoldColumn(false)]        
        public int Id { get; set; }
        [Key, Column(Order = 2)]
        public int? IdEleve { get; set; }
        [ForeignKey("IdEleve")]
        public virtual Eleve eleve {get; set;}
        [Key, Column(Order = 3)]
        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service service { get; set; }
        [Key, Column(Order = 4)]
        public int? IdExercice { get; set; }
        [ForeignKey("IdExercice")]
        public virtual Exercice exercice { get; set; }

      

    }
}