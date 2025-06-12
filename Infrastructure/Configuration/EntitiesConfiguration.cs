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
                builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100);
                builder.Property(p => p.Cuit).HasColumnName("Cuit");
                builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(100);

                builder.HasMany(p => p.Transactions)
                       .WithOne(t => t.Provider)
                       .HasForeignKey(t => t.ProviderId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }

        public class ClientConfiguration : IEntityTypeConfiguration<Client>
        {
            public void Configure(EntityTypeBuilder<Client> builder)
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100);
                builder.Property(c => c.Cuit).HasColumnName("Cuit");
                builder.Property(c => c.Adress).HasColumnName("Adress").HasMaxLength(100);
            }
        }

        public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
        {
            public void Configure(EntityTypeBuilder<Transaction> builder)
            {
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(t => t.Date).HasColumnName("Date").IsRequired();
                builder.Property(t => t.ClientId).HasColumnName("ClientId").IsRequired();
                builder.Property(t => t.ProviderId).HasColumnName("ProviderId").IsRequired();
                builder.Property(t => t.ConciliacionId).HasColumnName("ConciliacionId").IsRequired();
                builder.Property(t => t.Observation).HasColumnName("Observation").HasMaxLength(500);
                builder.Property(t => t.TransactionType).HasColumnName("TransactionType").IsRequired();

                builder.HasOne(t => t.Client)
                       .WithMany(c => c.Transactions)
                       .HasForeignKey(t => t.ClientId);

                builder.HasOne(t => t.Provider)
                       .WithMany(p => p.Transactions)
                       .HasForeignKey(t => t.ProviderId);

                builder.HasOne(t => t.Conciliation)
                       .WithMany(c => c.Transactions)
                       .HasForeignKey(t => t.ConciliacionId);

                builder.HasMany(t => t.Details)
                       .WithOne(d => d.Transaction)
                       .HasForeignKey(d => d.TransactionId);
            }
        }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100);
                builder.Property(p => p.ReferenceAmount).HasColumnName("ReferenceAmount").HasColumnType("decimal(18,2)");
                builder.Property(p => p.Stock).HasColumnName("Stock").IsRequired();
                builder.Property(p => p.Active).HasColumnName("Active").IsRequired();
            }
        }

        public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
        {
            public void Configure(EntityTypeBuilder<TransactionDetail> builder)
            {
                builder.HasKey(td => td.DetailId);
                builder.Property(td => td.DetailId).HasColumnName("DetailId").ValueGeneratedOnAdd().IsRequired();
                builder.Property(td => td.TransactionId).HasColumnName("TransactionId").IsRequired();
                builder.Property(td => td.ProductId).HasColumnName("ProductId").IsRequired();
                builder.Property(td => td.Quantity).HasColumnName("Quantity").IsRequired();
                builder.Property(td => td.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
                builder.Property(td => td.Total).HasColumnName("Total").HasColumnType("decimal(18,2)").IsRequired();
            }
        }

        public class ConciliationConfiguration : IEntityTypeConfiguration<Conciliation>
        {
            public void Configure(EntityTypeBuilder<Conciliation> builder)
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(c => c.StartDate).HasColumnName("StartDate").IsRequired();
                builder.Property(c => c.EndDate).HasColumnName("EndDate").IsRequired();
                builder.Property(c => c.UserResponsable).HasColumnName("UserResponsable").IsRequired();
                builder.Property(c => c.Active).HasColumnName("Active").IsRequired();
            }
        }

        public class Product_ProviderConfiguration : IEntityTypeConfiguration<Product_Provider>
        {
            public void Configure(EntityTypeBuilder<Product_Provider> builder)
            {
                builder.HasKey(pp => new { pp.ProductId, pp.ProviderId });
                builder.Property(pp => pp.ProductId).HasColumnName("ProductId").IsRequired();
                builder.Property(pp => pp.ProviderId).HasColumnName("ProviderId").IsRequired();
                builder.Property(pp => pp.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
            }
        }

    }
}
