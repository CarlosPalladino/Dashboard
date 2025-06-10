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
        DbSet<Client> Clients { get; set; }

        DbSet<Conciliation> Conciliations { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Provider> Providers { get; set; }

        DbSet<Transaction> Transactions { get; set; }

        DbSet<TransactionDetail> TransactionDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionDetailConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ConciliationConfiguration());
        }
    }
}
