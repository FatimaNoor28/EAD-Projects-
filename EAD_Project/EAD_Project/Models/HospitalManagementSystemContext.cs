using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EAD_Project.Models;

public partial class HospitalManagementSystemContext : DbContext
{
    public HospitalManagementSystemContext()
    {
    }

    public HospitalManagementSystemContext(DbContextOptions<HospitalManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__3214EC07C15ADE61");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).ValueGeneratedNever();
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC21FDC2B31");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__3214EC070C270AC5");

            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC36656161D77");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientId).ValueGeneratedNever();
            entity.Property(e => e.AppointmentDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Cnic)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("CNIC");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Doctor)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(11)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
