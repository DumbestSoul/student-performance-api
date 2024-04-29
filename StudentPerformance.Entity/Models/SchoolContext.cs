using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentPerformance.Entity.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marksheet> Marksheets { get; set; }

    public virtual DbSet<StudentMaster> StudentMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marksheet>(entity =>
        {
            entity.HasKey(e => e.MarksheetId).HasName("PK__Markshee__4482BB5484CFB9E0");

            entity.ToTable("Marksheet");

            entity.Property(e => e.MarksheetId).ValueGeneratedNever();
            entity.Property(e => e.MarksObtained).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Sub)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalMark)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Student).WithMany(p => p.Marksheets)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Marksheet__Stude__440B1D61");
        });

        modelBuilder.Entity<StudentMaster>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentM__32C52B99DD95A914");

            entity.ToTable("StudentMaster");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.StudentName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
