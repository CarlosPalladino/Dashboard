using Apllication.Interfaces.Repository;
using Apllication.Interfaces.Services;
using static Apllication.Records.ProductRecord;

namespace Infrastructure.Services.Services
{
    public class ProductService : IProductInterface
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task ChangeState(string name)
        {
            var product = await _repo.ProductDetail(name);
            if (product.Active) product.Desactivate(name);
            else product.Reactivate(name);
            await _repo.ProductUpdate(product);
        }

        public async Task<ProductsRecord> ProductInformation(string name)
        {
            var products = await _repo.ProductDetail(name);
            return new ProductsRecord(products.Name, products.Stock, products.ReferenceAmount);
        }

        public async Task<List<ProductsRecord>> ProductList()
        {
            var products = await _repo.ProductList();

            return products.Select(p => new ProductsRecord(p.Name, p.Stock, p.ReferenceAmount))
                    .ToList();
        }
    }
}
