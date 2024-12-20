using HospitalHandler.Enteties.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalHandler.Enteties.Data
{

    public class HospitalDbContext : DbContext
    {
        public DbSet<Name>? Names { get; set; }
        public DbSet<Patient>? Patients { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected HospitalDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Name>().HasData(new Name {
                Id = new Guid("d8ff176f-bd0a-4b8e-b329-871952e32e1f"),
                PatientId = new Guid("640b993b-9e7a-4a9a-9e53-5ac0067c8124"),
                Use = "official",
                Family = "Иванов",
                FirstName = "Иван",
                Surname = "Иванович" 
            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = new Guid("640b993b-9e7a-4a9a-9e53-5ac0067c8124"),
                Gender = "male",
                BirthdDate = new DateTime(2024, 1, 13, 18, 25, 43),
                Active = true
            });
        }
    }
}
