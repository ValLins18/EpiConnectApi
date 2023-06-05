using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data {
    public class AppDbContext : IdentityDbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Epi> Epis { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Warning> Warnings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new AlertConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EpiConfiguration());
            modelBuilder.ApplyConfiguration(new MetricsConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new WarningConfiguration());
        }
    }
}
