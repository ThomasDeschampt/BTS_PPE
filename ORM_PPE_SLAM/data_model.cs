using Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ORM_PPE_SLAM
{
    public partial class data_model : DbContext
    {
        public data_model()
            : base("name=data_model")
        {
        }

        public virtual DbSet<departement> departements { get; set; }
        public virtual DbSet<medecin> medecins { get; set; }
        public virtual DbSet<specialite> specialites { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departement>()
                .Property(e => e.nom_dep)
                .IsUnicode(false);

            modelBuilder.Entity<departement>()
                .Property(e => e.reg_dep)
                .IsUnicode(false);

            modelBuilder.Entity<departement>()
                .HasMany(e => e.medecins)
                .WithRequired(e => e.departement)
                .HasForeignKey(e => e.C_FK_id_dep)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<medecin>()
                .Property(e => e.nom_med)
                .IsUnicode(false);

            modelBuilder.Entity<medecin>()
                .Property(e => e.pre_med)
                .IsUnicode(false);

            modelBuilder.Entity<medecin>()
                .Property(e => e.adr_med)
                .IsUnicode(false);

            modelBuilder.Entity<medecin>()
                .Property(e => e.tel_med)
                .IsUnicode(false);

            modelBuilder.Entity<specialite>()
                .Property(e => e.lib_spe)
                .IsUnicode(false);

            modelBuilder.Entity<specialite>()
                .HasMany(e => e.medecins)
                .WithOptional(e => e.specialite)
                .HasForeignKey(e => e.C_FK_id_spe);
        }
    }
}
