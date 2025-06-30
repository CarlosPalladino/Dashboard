using static Apllication.Records.ProductRecord;

namespace Apllication.Interfaces.Services
{
    public interface IProductInterface
    {
        Task<List<ProductsRecord>> ProductList();
        Task<ProductsRecord> ProductInformation(string name);
        Task ChangeState(string name);
    }
}
