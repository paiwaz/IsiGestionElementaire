using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsiGestionElementaire.Models
{
    public class RapportEleve
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaiss { get; set; }
        public string LieuNaiss { get; set; }
    }

    public class RaportTuteur
    {      
        public string NomTuteur { get; set; }
        public string PrenomTuteur { get; set; }
        public string AdresseTuteur { get; set; }
        public string TelTuteur { get; set; }
       public string EmailTuteur { get; set; }
        
    }
}