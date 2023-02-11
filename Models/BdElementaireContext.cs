using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IsiGestionElementaire.Models
{
    public class BdElementaireContext:DbContext
    {
        public BdElementaireContext()
            : base("MaChaineConnexion")
        {
        }

        public DbSet<Tuteur> Tuteur { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Exercice> Exercice { get; set; }
        public DbSet<Eleve> Eleve { get; set; }
        public DbSet<ParentEleve> ParentEleve { get; set; }
        public DbSet<Affectee> affectee { get; set; }
        public DbSet<Inscription> inscription { get; set; }

    }
}