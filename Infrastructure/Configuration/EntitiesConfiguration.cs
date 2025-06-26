using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public static class EntitiesConfiguration
    {
        public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
        {
            public void Configure(EntityTypeBuilder<Provider> builder)
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
                builder.Property(p => p.Cuit).IsRequired();
                builder.Property(p => p.Email).HasMaxLength(100);

                builder.HasData(new Provider(
                    new Guid("6E1A72D3-5D4A-4F74-A8F0-521C45C8AC78"),
                    "Tech Solutions",
                    30765432109,
                    "contacto@techsolutions.com"
                ));
            }
        }

        public class ClientConfiguration : IEntityTypeConfiguration<Client>
        {
            public void Configure(EntityTypeBuilder<Client> builder)
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
                builder.Property(c => c.Cuit).IsRequired();
                builder.Property(c => c.Address).HasMaxLength(200);
                builder.Property(c => c.Active).HasDefaultValue(true);
                builder.HasData(new Client(
                    new Guid("3F2504E0-4F89-41D3-9A0C-0305E82C3301"),
                    "Juan Pérez EDITADO",
                     20456789012,
                     "Av. Siempre Viva 123",
                      active: false
                         ));
                builder.HasData(new Client(
                    new Guid("ee1560cf-efb0-458a-a3d8-e4dd16958461"),
                    "Juan Pérez",
                     20456789012,
                     "Av. Siempre Viva 321",
                      active: false
                         ));

            }
        }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
                builder.Property(p => p.ReferenceAmount).HasPrecision(18, 2).IsRequired();
                builder.Property(p => p.Stock).IsRequired();
                builder.Property(p => p.Active).IsRequired();

                builder.HasData(new Product(
                    new Guid("B234C2F0-721A-46F6-9F23-4D87C1B207C1"),
                    "Laptop",
                    1200m,
                    10,
                    true
                ));
            }
        }

        public class ConciliationConfiguration : IEntityTypeConfiguration<Conciliation>
        {
            public void Configure(EntityTypeBuilder<Conciliation> builder)
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.StartDate).IsRequired();
                builder.Property(c => c.EndDate).IsRequired();
                builder.Property(c => c.UserResponsable).HasMaxLength(100).IsRequired();
                builder.Property(c => c.Active).IsRequired();

                builder.HasData(new Conciliation(
                    new Guid("5D6A2F00-AB9E-4D4B-A727-6B12D26E3F98"),
                    new DateTime(2025, 6, 12),
                    new DateTime(2025, 6, 19),
                    "Admin",
                    true
                ));
            }
        }

        public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
        {
            public void Configure(EntityTypeBuilder<Transaction> builder)
            {
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Date).IsRequired();
                builder.Property(t => t.Observation).HasMaxLength(500);

                builder.HasOne<Client>()
                    .WithMany()
                    .HasForeignKey(t => t.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<Provider>()
                    .WithMany()
                    .HasForeignKey(t => t.ProviderId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasData(new Transaction(
                    new Guid("9F0C2D3E-8A23-4039-BAC5-987C6F8E1AB2"),
                    new DateTime(2025, 6, 12),
                    new Guid("3F2504E0-4F89-41D3-9A0C-0305E82C3301"),
                    new Guid("6E1A72D3-5D4A-4F74-A8F0-521C45C8AC78"),
                    "Primera transacción de prueba"
                ));
            }
        }

        public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
        {
            public void Configure(EntityTypeBuilder<TransactionDetail> builder)
            {
                builder.HasKey(td => td.Id);
                builder.Property(td => td.Quantity).IsRequired();
                builder.Property(td => td.Amount).HasPrecision(18, 2).IsRequired();
                builder.Property(td => td.Total).HasPrecision(18, 2).IsRequired();

                builder.HasOne<Transaction>()
                    .WithMany()
                    .HasForeignKey(td => td.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(td => td.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasData(new TransactionDetail(
                    new Guid("FA0D92E6-B372-4B08-9BA8-75E3F21A44D6"),
                    new Guid("9F0C2D3E-8A23-4039-BAC5-987C6F8E1AB2"),
                    new Guid("B234C2F0-721A-46F6-9F23-4D87C1B207C1"),
                    1,
                    1200m,
                    1200m
                ));
            }
        }

        public class ProviderProductPricingConfiguration : IEntityTypeConfiguration<ProviderProductPricing>
        {
            public void Configure(EntityTypeBuilder<ProviderProductPricing> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Amount)
                       .HasPrecision(18, 4)
                       .IsRequired();

                builder.Property(p => p.ValidFrom)
                       .IsRequired();

                builder.HasOne<Provider>()
                       .WithMany()
                       .HasForeignKey(p => p.ProviderId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<Product>()
                       .WithMany()
                       .HasForeignKey(p => p.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasData(new ProviderProductPricing(
                    new Guid("E1B9A9DD-7B52-4A88-9A7F-123456789ABC"),
                    new Guid("6E1A72D3-5D4A-4F74-A8F0-521C45C8AC78"),
                    new Guid("B234C2F0-721A-46F6-9F23-4D87C1B207C1"),
                    1234.5678m,
                    DateTime.UtcNow.Date
                ));
            }
        }

    }
}
