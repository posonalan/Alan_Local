using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionStockAppli.Data.Models;

#nullable disable

namespace GestionStockAppli.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<article> Articles { get; set; }
        public virtual DbSet<category> Categories { get; set; }
        public virtual DbSet<typesproduit> TypesProduits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           optionsBuilder.UseMySQL("server=localhost;user=root;database=gestionstockbdd;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<article>(entity =>
            {
                entity.HasKey(e => e.IdArticle)
                    .HasName("PRIMARY");

                //entity.HasIndex(e => e.IdCategorie, "FK_Categorie");

                //entity.Property(e => e.IdArticle).HasColumnType("int(11)");

                //entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                //entity.Property(e => e.LibelleArticle).HasMaxLength(100);

                //entity.Property(e => e.QuantiteStockee).HasColumnType("int(11)");

                //entity.HasOne(d => d.IdCategorieNavigation)
                //    .WithMany(p => p.articles)
                //    .HasForeignKey(d => d.IdCategorie)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Categorie");
            });

            modelBuilder.Entity<category>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PRIMARY");

                //entity.HasIndex(e => e.IdTypesProduits, "FK_TypeProduit");

                //entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                //entity.Property(e => e.IdTypesProduits).HasColumnType("int(11)");

                //entity.Property(e => e.LibelleCategorie).HasMaxLength(100);

                //entity.HasOne(d => d.IdTypesProduitsNavigation)
                //    .WithMany(p => p.categories)
                //    .HasForeignKey(d => d.IdTypesProduits)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TypeProduit");
            });

            modelBuilder.Entity<typesproduit>(entity =>
            {
                entity.HasKey(e => e.IdTypeProduit)
                    .HasName("PRIMARY");

                //entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");

                //entity.Property(e => e.LibelleTypeProduit).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
