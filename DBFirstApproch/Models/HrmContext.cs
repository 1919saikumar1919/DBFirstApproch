using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApproch.Models;

public partial class HrmContext : DbContext
{
    public HrmContext()
    {
    }

    public HrmContext(DbContextOptions<HrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Parson> Parsons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0JAKMNT; Database=HRM; Trusted_Connection=True; MultipleActiveResultSets=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasIndex(e => e.ParsonId, "IX_Candidates_ParsonId");

            entity.Property(e => e.CandidateId).ValueGeneratedNever();

          //  entity.HasOne(d => d.Parson).WithMany(p => p.Candidates).HasForeignKey(d => d.ParsonId);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.CandidateId, "IX_Employees_CandidateId");

            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.Candidate).WithMany(p => p.Employees).HasForeignKey(d => d.CandidateId);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentId);
        });

        modelBuilder.Entity<Parson>(entity =>
        {
            entity.Property(e => e.ParsonId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
