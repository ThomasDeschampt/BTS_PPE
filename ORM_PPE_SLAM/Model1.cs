using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ORM_PPE_SLAM
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<Joueurs> Joueurs { get; set; }
        public virtual DbSet<Match_Equipes> Match_Equipes { get; set; }
        public virtual DbSet<Match_joueur> Match_joueur { get; set; }
        public virtual DbSet<Matchs> Matchs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipes>()
                .Property(e => e.NOM_Equipe)
                .IsUnicode(false);

            modelBuilder.Entity<Equipes>()
                .Property(e => e.LIB_Equipe)
                .IsUnicode(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.Joueurs)
                .WithRequired(e => e.Equipes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.Match_Equipes)
                .WithRequired(e => e.Equipes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .Property(e => e.NOM_Joueur)
                .IsUnicode(false);

            modelBuilder.Entity<Joueurs>()
                .Property(e => e.PRENOM_Joueur)
                .IsUnicode(false);

            modelBuilder.Entity<Joueurs>()
                .Property(e => e.POSTE_Joueur)
                .IsUnicode(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.Match_joueur)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .Property(e => e.LIEU_Match)
                .IsUnicode(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.Match_Equipes)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.Match_joueur)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);
        }
    }
}
