﻿using System;
using ECF.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;




namespace ECF.Data
{
    public partial class EcfContext : DbContext
    {
        public EcfContext()
        {
        }

        public EcfContext(DbContextOptions<EcfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Musicien> Musiciens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
       optionsBuilder.UseMySQL("server=localhost;user=root;database=ecf;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groupe>(entity =>
            {
                entity.HasKey(e => e.IdGroupe)
                    .HasName("PRIMARY");

                entity.ToTable("groupes");

                entity.Property(e => e.IdGroupe).HasColumnType("int(11)");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NomDuGroupe)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreDeFollowers).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Musicien>(entity =>
            {
                entity.HasKey(e => e.IdMusicien)
                    .HasName("PRIMARY");

                entity.ToTable("musiciens");

                entity.HasIndex(e => e.IdGroupe, "FK_Membres_Groupes");

                entity.Property(e => e.IdMusicien)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMusicien");

                entity.Property(e => e.IdGroupe).HasColumnType("int(11)");

                entity.Property(e => e.Instrument)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany(p => p.Musiciens)
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membres_Groupes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
