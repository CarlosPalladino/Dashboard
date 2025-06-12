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



            }
        }

        public class ClientConfiguration : IEntityTypeConfiguration<Client>
        {
            public void Configure(EntityTypeBuilder<Client> builder)
            {

            }
        }
        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {

            }



        }

        public class ConciliationConfiguration : IEntityTypeConfiguration<Conciliation>
        {
            public void Configure(EntityTypeBuilder<Conciliation> builder)

            {

            }
        }
        public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
        {
            public void Configure(EntityTypeBuilder<Transaction> builder)
            {

            }
        }

        public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
        {
            public void Configure(EntityTypeBuilder<TransactionDetail> builder)
            {


            }
        }

    }
}