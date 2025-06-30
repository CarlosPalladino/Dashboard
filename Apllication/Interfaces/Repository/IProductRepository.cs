namespace Apllication.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> ProductList();
        Task<Product> ProductDetail(string name);
        Task ProductUpdate(Product product);
        Task<bool> IsActive(string name);
    }
}
