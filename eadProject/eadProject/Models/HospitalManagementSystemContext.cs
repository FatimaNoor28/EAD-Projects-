using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace eadProject.Models
{
    public partial class HospitalManagementSystemContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Reports> Reports { get; set; }
        public HospitalManagementSystemContext()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

           //=> options.UseSqlServer($"Server = backend; Database = master; User = sa; Password = Docker123!; TrustServerCertificate=true; encrypt=false");
        public override int SaveChanges()
        {
            ProccessSave();
            return base.SaveChanges();
        }
        private void ProccessSave()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAudinModel)
                {
                    var referenceEntity = entry.Entity as FullAudinModel;
                    switch (entry.State)
                    {
                        case EntityState.Added:

                            referenceEntity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            break;
                    }
                }
            }
        }

    }
}
