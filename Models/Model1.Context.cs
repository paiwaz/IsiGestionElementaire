﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsiGestionElementaire.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BdElementaireEntities : DbContext
    {
        public BdElementaireEntities()
            : base("name=BdElementaireEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VParentEleve> VParentEleve { get; set; }
        public virtual DbSet<VEleveTuteurRPT> VEleveTuteurRPT { get; set; }
        public virtual DbSet<VTuteur> VTuteur { get; set; }
    }
}
