using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EAD_Project.Models;
public partial class HospitalManagementSystemContext : DbContext {
    public  DbSet<Admin> Admins { get; set; }

    public  DbSet<Appointment> Appointments { get; set; }

    public  DbSet<Doctor> Doctors { get; set; }

    public  DbSet<Patient> Patients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
}