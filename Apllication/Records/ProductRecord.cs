namespace Apllication.Records
{
    public class ProductRecord
    {
        public record ProductSummary(int TotalProducts, decimal TotalRevenue, List<TopProduct> TopProducts);
        public record TopProduct(string Name, int quantitySold);
        public record ProductsRecord(string name, int Stock, decimal referencAmount);
    }
}
