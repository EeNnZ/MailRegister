using System;
using System.Collections.Generic;
using MailRegisterServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailRegisterServer;

public partial class CompanyDbContext : DbContext
{
    //public CompanyDbContext()
    //{
    //}

    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Mail> Mail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0736C0F0DB");

            entity.ToTable("Employee");

            entity.Property(e => e.Age).HasDefaultValueSql("((18))");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.JobTitle).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<Mail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mail__3214EC07EFC40749");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.Addressee).WithMany(p => p.MailRecieved)
                .HasForeignKey(d => d.AddresseeId)
                .HasConstraintName("FK__Mail__AddresseeI__3D5E1FD2");

            entity.HasOne(d => d.Sender).WithMany(p => p.MailSent)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Mail__SenderId__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
