using Domain;
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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker
                .Entries<Entity<Guid>>()
                .Where(x => x.Entity.DomainEvents.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                Console.WriteLine($"🟢 Domain Event fired: {domainEvent.GetType().Name} at {domainEvent.OccurredOn}");
            }

            return result;
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Conciliation> Conciliations { get; set; }
        public DbSet<ConciliationTransaction> ConciliationTransactions { get; set; }
        public DbSet<ProviderProductPricing> ProviderProductPricing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.ConciliationConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EntitiesConfiguration.TransactionDetailConfiguration());
            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
