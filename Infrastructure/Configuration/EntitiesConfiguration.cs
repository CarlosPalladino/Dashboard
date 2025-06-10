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
            }
        }

        public class ClientConfiguration : IEntityTypeConfiguration<Client>
        {
            public void Configure(EntityTypeBuilder<Client> builder)
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100);
                builder.Property(p => p.Cuit).HasColumnName("Cuit");
                builder.Property(p => p.Adress).HasColumnName("Adress").HasMaxLength(100);
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
                builder.Property(t => t.EnumType).HasColumnName("EnumType").IsRequired();
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
                builder.Property(td => td.Total).HasColumnName("Total").HasColumnType("int").IsRequired(); // corregido
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

     


    }
}
