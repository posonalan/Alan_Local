using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfApp2.Data.Models;

#nullable disable

namespace WpfApp2.Data
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

        public virtual DbSet<Entite1> Entite1 { get; set; }
        public virtual DbSet<Entite2> Entite2 { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=app1;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entite1>(entity =>
            {
                entity.HasKey(e => e.IdEntite1)
                    .HasName("PRIMARY");

                //    entity.ToTable("entite1");

                //    entity.Property(e => e.IdEntite1).HasColumnType("int(11)");

                //    entity.Property(e => e.NomEntite1)
                //        .IsRequired()
                //        .HasMaxLength(50);

                //    entity.Property(e => e.idEntite2).HasColumnType("int(11)");
                });

                modelBuilder.Entity<Entite2>(entity =>
                {
                    entity.HasKey(e => e.idEntite2)
                        .HasName("PRIMARY");

                    //    entity.ToTable("entite2");

                    //    entity.Property(e => e.idEntite2).HasColumnType("int(11)");

                    //    entity.Property(e => e.NomEntite2)
                    //        .IsRequired()
                    //        .HasMaxLength(50);
                });


                OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
