namespace Apllication.Records
{
    public class ProductRecords
    {
        public record ProductSummary(int TotalProducts, decimal TotalRevenue, List<TopProduct> TopProducts);

        public record TopProduct(string Name, int QuantitySold);

    }
}
