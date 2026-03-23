using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data;

public partial class AppDbCtx : DbContext
{
    public AppDbCtx()
    {
    }

    public AppDbCtx(DbContextOptions<AppDbCtx> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrol> Enrols { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3213E83FC6CEF303");
        });

        modelBuilder.Entity<Enrol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrol__3213E83F177A4D00");

            entity.HasOne(d => d.Cou).WithMany(p => p.Enrols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrol__couId__4F7CD00D");

            entity.HasOne(d => d.Stud).WithMany(p => p.Enrols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrol__studId__4E88ABD4");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3213E83F0D75DE49");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
