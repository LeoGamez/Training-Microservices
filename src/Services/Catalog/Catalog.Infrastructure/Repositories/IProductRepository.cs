using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        Task<Product> GetProductById(string id);
        Task<Product> GetProductByName(string name);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
