using Apllication.Interfaces.Repository;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IsActive(string name)
        {
            var isActive = await _context.Products
                .Where(p => p.Name.Equals(name))
                .FirstOrDefaultAsync();

            return isActive?.Active ?? false;
        }
        public async Task<Product> ProductDetail(string name)
        {
            var productDetail = await _context.Products
                                        .Where(p => p.Name.Equals(name) || p.Name.Contains(name))
                                        .FirstOrDefaultAsync();
            return productDetail;
        }
        public async Task<List<Product>> ProductList()
        {
            return await _context.Products
                .Where(p => p.Active)
                .ToListAsync();
        }
        public async Task ProductUpdate(Product product)
        {
            var productToUpdate = _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
