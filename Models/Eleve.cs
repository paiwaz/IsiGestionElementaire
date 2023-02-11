using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IsiGestionElementaire.Models
{
    public class Eleve
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Matricule"), 
            Required(ErrorMessage = "*"), MaxLength(10)]
        public string Matricule { get; set; }

        [Display(Name = "Nom"),
            Required(ErrorMessage = "*"), MaxLength(40)]
        public string Nom { get; set; }

        [Display(Name = "Prénom"),
            Required(ErrorMessage = "*"), MaxLength(50)]
        public string Prenom { get; set; }

        [Display(Name = "sexe"),
            Required(ErrorMessage = "*"), MaxLength(1)]
        public string Sexe { get; set; }

        [Display(Name = "Date de Naissance"),
            Required(ErrorMessage = "*") ]
        public DateTime? DateNaiss { get; set; }

        [Display(Name = "Lieu de Naissance"),
            Required(ErrorMessage = "*"), MaxLength(80)]
        public string LieuNaiss { get; set; }

    }

    public class EleveViewModel
    {
      
        public int Id { get; set; }

        [Display(Name = "Matricule"),
            Required(ErrorMessage = "*"), MaxLength(10)]
        public string Matricule { get; set; }

        [Display(Name = "Nom"),
            Required(ErrorMessage = "*"), MaxLength(40)]
        public string Nom { get; set; }

        [Display(Name = "Prénom"),
            Required(ErrorMessage = "*"), MaxLength(50)]
        public string Prenom { get; set; }

        [Display(Name = "sexe"),
            Required(ErrorMessage = "*"), MaxLength(1)]
        public string Sexe { get; set; }

        [Display(Name = "Date de Naissance"),
            Required(ErrorMessage = "*")]
        public DateTime? DateNaiss { get; set; }

        [Display(Name = "Lieu de Naissance"),
            Required(ErrorMessage = "*"), MaxLength(80)]
        public string LieuNaiss { get; set; }

        //Espace Tuteur
        public int idTuteur { get; set; }
        [Display(Name = "Priorite"),
            Required(ErrorMessage = "*")]
        public bool priorite { get; set; }

        //Espace Service
        public int idService { get; set; }
        public int idExercice { get; set; }

        //Espace Classe

        public int idClasse { get; set; }
        public int idExerciceClasse { get; set; }


    }

    public class rptEleve
    {
        public string Matricule { get; set; }       
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaiss { get; set; }
        public string LieuNaiss { get; set; }

    }

    public class rptEleveTuteur
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaiss { get; set; }
        public string LieuNaiss { get; set; }
        public string CNI { get; set; }
        public string NomTuteur { get; set; }
        public string PrenomTuteur { get; set; }
        public string AdresseTuteur { get; set; }
        public string TelTuteur { get; set; }
    }
}