using EmploymentAgencyApi.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.IO;

namespace EmploymentAgencyApi.DataBase
{
    public class AgencyDbContext : DbContext
    {
        private const string connectionString = "Server=LAPTOP-SLAGE0DE;Database=EmploymentAgencyDB;Trusted_Connection=True;";

        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerAddress> EmployerAddresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>()
                .Property(e => e.Name).HasMaxLength(30);

            modelBuilder.Entity<Employer>()
                .Property(e => e.LastName).HasMaxLength(40);

            modelBuilder.Entity<Employer>()
                .Property(e => e.LastName).HasMaxLength(40);

            modelBuilder.Entity<Employer>()
                .Property(e => e.PhoneNumber).HasMaxLength(15);

            modelBuilder.Entity<Employer>()
                .Property(e => e.Nationality).HasMaxLength(30);

            modelBuilder.Entity<EmployerAddress>()
                .Property(e => e.City).HasMaxLength(30);

            modelBuilder.Entity<EmployerAddress>()
                .Property(e => e.Street).HasMaxLength(60);

            modelBuilder.Entity<EmployerAddress>()
                .Property(e => e.PostalCode).HasMaxLength(6);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name).HasMaxLength(40);

            modelBuilder.Entity<Company>()
                .Property(e => e.Size).IsRequired(false)
                                      .HasMaxLength(20);

            modelBuilder.Entity<CompanyAddress>()
                .Property(e => e.City).HasMaxLength(30);

            modelBuilder.Entity<CompanyAddress>()
                .Property(e => e.Street).HasMaxLength(60);

            modelBuilder.Entity<CompanyAddress>()
                .Property(e => e.PostalCode).HasMaxLength(6);

            modelBuilder.Entity<Contract>()
                .Property(c => c.ContractNumber).HasMaxLength(10);

            modelBuilder.Entity<Contract>()
                .Property(c => c.Position).HasMaxLength(50);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        
    }
}
