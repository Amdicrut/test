using Microsoft.EntityFrameworkCore;
using WebServer.Data.Models;

namespace WebServer.Data
{
    public class StorageContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(@"Host=localhost;Database=datafirst;Username=postgres;Password=1234")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Transport>().Property(p => p.Id).ValueGeneratedOnAdd();



            modelBuilder.Entity<Cargo>().HasMany(car => car.Transports).WithOne(tran => tran.Cargo);
            modelBuilder.Entity<Customer>().HasMany(cust => cust.Cargos).WithOne(car => car.Customer);

        }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transport> Transports { get; set; }
    }
}
