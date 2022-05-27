using Catalog.Domain.Entities;
using Catalog.Infrastructure.Context;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext context;

        public ProductRepository(ICatalogContext context)
        {
            this.context = context;
        }

        public Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByCategory(string categoryName)
        {
            return await context.Products.Find(p => p.Category == categoryName).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await context.Products.Find(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.Find(p => true).ToListAsync();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
