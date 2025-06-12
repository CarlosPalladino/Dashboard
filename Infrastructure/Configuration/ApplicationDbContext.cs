using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
