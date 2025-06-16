namespace Apllication.Records
{
    public class ProductRecord
    {
        public record ProductSummary(int TotalProducts, decimal TotalRevenue, List<TopProduct> TopProducts);

        public record TopProduct(string Name, int QuantitySold);

    }
}
