using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurartion
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Conciliation> Conciliations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        public DbSet<Product_Provider> Product_Providers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionDetailConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ConciliationConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.Product_ProviderConfiguration());
        }
    }
}
