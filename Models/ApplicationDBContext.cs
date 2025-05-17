using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NIC_PRACTICAL.Models;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:nictest.database.windows.net,1433;Initial Catalog=nictest;Persist Security Info=False;User ID=nictest;Password=shuaibS1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptCode);

            entity.ToTable("dept_table");

            entity.Property(e => e.DeptCode).HasColumnName("Dept_Code");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dept_Name");
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.ToTable("student_details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeptCode).HasColumnName("dept_code");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_name");
            entity.Property(e => e.StudentRoll).HasColumnName("student_roll");
            entity.Property(e => e.TotalMarks)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("total_marks");
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table_1");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
