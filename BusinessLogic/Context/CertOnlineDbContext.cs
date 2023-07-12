using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Context;

public partial class CertOnlineDbContext : DbContext
{
    public CertOnlineDbContext()
    {
    }

    public CertOnlineDbContext(DbContextOptions<CertOnlineDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certification> Certifications { get; set; }
    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamAttempt> ExamAttempts { get; set; }
    public virtual DbSet<Professional> Professionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
        => optionsBuilder.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database/Data.sqlite")}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Certifications_Name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CertificationId).HasColumnName("CertificationID");

            entity.HasOne(d => d.Certification).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CertificationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExamAttempt>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttemptDate).HasColumnType("DATE");
            entity.Property(e => e.ExamId).HasColumnName("ExamID");
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamAttempts)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Professional).WithMany(p => p.ExamAttempts)
                .HasForeignKey(d => d.ProfessionalId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Professionals_Name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
