using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace nutcache_challenge_LeopoldoReginato_backend.Models
{
    public partial class DBNutcacheContext : DbContext
    {
        public DBNutcacheContext()
        {
        }

        public DBNutcacheContext(DbContextOptions<DBNutcacheContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.BirthDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).IsRequired().HasColumnType("datetime");

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Employee)
                    .IsRequired()
                    .HasForeignKey(d => d.IdGender)
                    .HasConstraintName("FK__Employee__IdGender__286302EC");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdTeam)
                    .HasConstraintName("FK__Employee__IdTeam__29572725");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
