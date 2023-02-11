using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IsiGestionElementaire.Models
{
    public class Tuteur
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Display(Name ="CNI/Passport"), MaxLength(20), Required(ErrorMessage ="*")]
        public string CNI { get; set; }
        [Display(Name = "Nom"), MaxLength(80), Required(ErrorMessage = "*")]
        public string NomTuteur { get; set; }
        [Display(Name = "Prenom"), MaxLength(80), Required(ErrorMessage = "*")]
        public string PrenomTuteur { get; set; }
        [Display(Name = "Adresse"), MaxLength(150), Required(ErrorMessage = "*")]
        public string AdresseTuteur { get; set; }
        [Display(Name = "Téléphone"), MaxLength(20), Required(ErrorMessage = "*")]
        public string TelTuteur { get; set; }
        [Display(Name = "Email"), MaxLength(80), DataType(DataType.EmailAddress, ErrorMessage ="Invalide Email")]
        public string EmailTuteur { get; set; }
        [Display(Name = "Civilité"), MaxLength(5), Required(ErrorMessage = "*")]
        public string CiviliteTuteur { get; set; }
        [Display(Name = "Parenté"), MaxLength(20), Required(ErrorMessage = "*")]
        public string Parente { get; set; }
    }
}